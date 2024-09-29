using TekhnelogosOkr.Core.DataAccess.Abstract;
using TekhnelogosOkr.Entity.Concrete;
using TekhnelogosOkr.ViewModel.User;

namespace TekhnelogosOkr.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        Task<UserDetailViewModel> GetUserDetailsByIdAsync(int userId);

        Task<string> GetUserRoleNameAsync(int userId);

        Task<List<UserViewModel>> GetAllUsersWithDetailsAsync();

        Task<List<ManagerViewModel>> GetSubordinatesAsync(int managerId);
    }
}