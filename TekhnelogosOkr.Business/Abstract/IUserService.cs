using TekhnelogosOkr.Core.Utilities.Results;
using TekhnelogosOkr.ViewModel.User;

namespace TekhnelogosOkr.Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<List<UserViewModel>>> GetAllDetailUsersAsync();

        Task<IDataResult<UserDetailViewModel>> GetUserDetailByIdAsync(int id);

        Task<IResult> DeactivateUserAsync(int id, UpdateUserViewModel userActiveViewModel);

        Task<IResult> LdapCreateUserAsync(LdapUserViewModel userViewModel);

        Task<int?> GetManagerIdByEmailAsync(string email);

        Task<LdapUserViewModel> GetUserByEmailAsync(string emailAddress);

        Task<IResult> LdapUpdateUserAsync(LdapUserViewModel userViewModel);

        Task<string> GetUserRoleAsync(int userId);

        Task<IDataResult<List<ManagerViewModel>>> GetSubordinatesAsync(int managerId);
    }
}