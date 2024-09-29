using Microsoft.Extensions.Options;
using System.DirectoryServices;
using TekhnelogosOkr.Business.Abstract;
using TekhnelogosOkr.Business.Configurations;
using TekhnelogosOkr.ViewModel.Department;
using TekhnelogosOkr.ViewModel.User;

namespace TekhnelogosOkr.Business.Concrete
{
    public class LdapManager : ILdapService
    {
        private readonly LdapSettings _ldapSettings;
        private readonly IDepartmentService _departmentService;
        private readonly IUserService _userService;

        public LdapManager(IOptions<LdapSettings> ldapSettings, IDepartmentService departmentService, IUserService userService)
        {
            _ldapSettings = ldapSettings.Value;
            _departmentService = departmentService;
            _userService = userService;
        }

        public async Task ImportUsersFromLdapAsync()
        {
            try
            {
                using DirectoryEntry ldapConnection = new(_ldapSettings.Path, _ldapSettings.Username, _ldapSettings.Password)
                {
                    AuthenticationType = AuthenticationTypes.Secure
                };

                using DirectorySearcher searcher = new DirectorySearcher(ldapConnection)
                {
                    Filter = "(objectClass=user)"
                };

                searcher.PropertiesToLoad.AddRange(new[] { "givenName", "sn", "whenCreated", "department", "userAccountControl", "mail", "manager" });

                var searchResults = searcher.FindAll();

                foreach (SearchResult result in searchResults)
                {
                    await ProcessUser(result.GetDirectoryEntry());
                }
            }
            catch (Exception ex)
            {
                ApplicationException applicationException = new ApplicationException($"LDAP'den kullanıcıları içe aktarırken bir hata oluştu: {ex.Message}", ex);
                throw applicationException;
            }
        }

        private async Task ProcessUser(DirectoryEntry userEntry)
        {
            var departmentName = userEntry.Properties["department"].Value?.ToString();
            var managerDn = userEntry.Properties["manager"].Value?.ToString();
            var managerEmail = GetManagerEmailByDn(managerDn);
            var managerId = !string.IsNullOrEmpty(managerEmail)
                    ? await _userService.GetManagerIdByEmailAsync(managerEmail)
                    : null;

            if (!string.IsNullOrEmpty(departmentName))
            {
                await EnsureDepartmentExistsAsync(departmentName);
            }

            var departmentId = await _departmentService.GetDepartmentIdByNameAsync(departmentName);

            var userDto = new LdapUserViewModel
            {
                FirstName = userEntry.Properties["givenName"].Value?.ToString(),
                LastName = userEntry.Properties["sn"].Value?.ToString(),
                StartWorkDate = ConvertToDateTime(userEntry.Properties["whenCreated"].Value),
                EmailAddress = userEntry.Properties["mail"].Value?.ToString(),
                IsActive = IsUserActive(userEntry.Properties["userAccountControl"].Value),
                ManagerID = managerId,
                DepartmentID = departmentId,
            };

            if (userDto.IsActive && userDto.FirstName != null && departmentName != null)
            {
                var existingUser = await _userService.GetUserByEmailAsync(userDto.EmailAddress);
                if (existingUser == null)
                {
                    await _userService.LdapCreateUserAsync(userDto);
                }
                else
                {
                    await _userService.LdapUpdateUserAsync(userDto);
                }
            }
        }

        //Ldaptan gelen departmanları veritabanına eklemek ve güncellemek için
        private async Task EnsureDepartmentExistsAsync(string departmentName)
        {
            var existingDepartmentId = await _departmentService.GetDepartmentIdByNameAsync(departmentName);
            if (!existingDepartmentId.HasValue)
            {
                var newDepartmentViewModel = new DepartmentViewModel
                {
                    Name = departmentName,
                };
                await _departmentService.CreateDepartmentAsync(newDepartmentViewModel);
            }
            else
            {
                var newDepartmentViewModel = new DepartmentViewModel
                {
                    Name = departmentName,
                };
                await _departmentService.LdapUpdateDepartmentAsync(newDepartmentViewModel);
            }
        }

        //LDAP'tan tarih kısmı object olarak geldiği için tarihi datetime türüne dönüştürmek için
        private DateTime? ConvertToDateTime(object whenCreatedValue)
        {
            return DateTime.TryParse(whenCreatedValue?.ToString(), out DateTime result) ? result : null;
        }

        private bool IsUserActive(object userAccountControlValue)
        {
            if (userAccountControlValue == null) return false;

            var userAccountControl = Convert.ToInt32(userAccountControlValue);
            return (userAccountControl & 0x2) == 0;
        }

        //Kullanıcıya ait menajerin emailini almak için
        private string? GetManagerEmailByDn(string managerDn)
        {
            if (string.IsNullOrEmpty(managerDn)) return null;

            try
            {
                using var ldapConnection = new DirectoryEntry(_ldapSettings.Path, _ldapSettings.Username, _ldapSettings.Password)
                {
                    AuthenticationType = AuthenticationTypes.Secure
                };

                using var searcher = new DirectorySearcher(ldapConnection)
                {
                    Filter = $"(distinguishedName={managerDn})"
                };
                searcher.PropertiesToLoad.Add("mail");

                var result = searcher.FindOne();
                return result?.GetDirectoryEntry().Properties["mail"].Value?.ToString();
            }
            catch (Exception ex)
            {
                ApplicationException applicationException = new ApplicationException($"Yönetici e-postası alınırken bir hata oluştu: {ex.Message}", ex);
                throw applicationException;
            }
        }
    }
}