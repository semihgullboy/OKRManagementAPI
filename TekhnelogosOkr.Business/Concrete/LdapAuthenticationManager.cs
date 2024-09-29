using Microsoft.Extensions.Options;
using System.DirectoryServices;
using System.Net;
using System.Security.Claims;
using TekhnelogosOkr.Business.Abstract;
using TekhnelogosOkr.Business.Configurations;
using TekhnelogosOkr.Business.Constants;
using TekhnelogosOkr.Core.Utilities.Results;
using TekhnelogosOkr.ViewModel.Authentication;

namespace TekhnelogosOkr.Business.Concrete
{
    public class LdapAuthenticationManager : IAuthenticationService
    {
        private readonly LdapSettings _ldapSettings;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IDepartmentService _departmentService;

        public LdapAuthenticationManager(IOptions<LdapSettings> ldapSettings, IUserService userService, ITokenService tokenService, IDepartmentService departmentService)
        {
            _ldapSettings = ldapSettings.Value;
            _userService = userService;
            _tokenService = tokenService;
            _departmentService = departmentService;
        }

        public async Task<IResult> Login(UserLoginViewModel user)
        {
            try
            {
                using DirectoryEntry ldapConnection = new(_ldapSettings.Path, _ldapSettings.Username, _ldapSettings.Password);
                ldapConnection.AuthenticationType = AuthenticationTypes.Secure;
                using DirectorySearcher searcher = new(ldapConnection);
                searcher.Filter = $"(&(objectClass=user)(mail={user.Email}))";
                searcher.PropertiesToLoad.Add("mail");

                SearchResult searchResult = searcher.FindOne();

                if (searchResult != null)
                {
                    bool isPasswordValid = await CheckUserPasswordAsync(searchResult.Path, user.Email, user.Password);
                    if (isPasswordValid)
                    {
                        return await GenerateTokenForUser(user.Email);
                    }
                    else
                    {
                        return new ErrorResult(Messages.UserAuthenticationFailed, (int)HttpStatusCode.Unauthorized);
                    }
                }
                else
                {
                    return new ErrorResult(Messages.UserNotFound, (int)HttpStatusCode.NotFound);
                }
            }
            catch (Exception)
            {
                return new ErrorResult("Bir hata oluştu. Lütfen daha sonra tekrar deneyin.", (int)HttpStatusCode.InternalServerError);
            }
        }

        private async Task<IResult> GenerateTokenForUser(string email)
        {
            var userInDb = await _userService.GetUserByEmailAsync(email);
            if (userInDb != null && userInDb.IsActive)
            {
                var userRole = await _userService.GetUserRoleAsync(userInDb.Id);
                var isDepartmentManager = await _departmentService.IsUserDepartmentManagerAsync(userInDb.Id);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, userInDb.Id.ToString()),
                    new Claim(ClaimTypes.Name , userInDb.FirstName),
                    new Claim(ClaimTypes.Surname , userInDb.LastName),
                    new Claim(ClaimTypes.Email, userInDb.EmailAddress),
                    new Claim(ClaimTypes.Role, userRole),
                    new Claim("IsDepartmentManager", isDepartmentManager.ToString())
                };

                var token = _tokenService.GenerateToken(claims);

                return new SuccessDataResult<string>(token, Messages.UserAuthenticated);
            }
            else
            {
                return new ErrorResult(Messages.UserDbNotFound, (int)HttpStatusCode.NotFound);
            }
        }

        private static async Task<bool> CheckUserPasswordAsync(string ldapPath, string email, string password)
        {
            try
            {
                using var userEntry = new DirectoryEntry(ldapPath, email, password);
                userEntry.AuthenticationType = AuthenticationTypes.Secure;

                return userEntry.NativeObject != null;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}