using Microsoft.EntityFrameworkCore;
using TekhnelogosOkr.Core.DataAccess.Concrete.EntityFramework;
using TekhnelogosOkr.DataAccess.Abstract;
using TekhnelogosOkr.DataAccess.Concrete.Context;
using TekhnelogosOkr.Entity.Concrete;
using TekhnelogosOkr.ViewModel.User;

namespace TekhnelogosOkr.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, TekhnelogosOkrContext>, IUserDal
    {
        private readonly TekhnelogosOkrContext _context;

        public EfUserDal(TekhnelogosOkrContext context) : base(context)
        {
            _context = context;
        }

        public async Task<string> GetUserRoleNameAsync(int userId)
        {
            var user = await _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user?.UserRoles != null)
            {
                var roleNames = user.UserRoles
                .Select(ur => ur.Role.Name)
                .Distinct()
                .ToList();

                return string.Join(", ", roleNames);
            }

            return "Unknown";
        }

        public async Task<UserDetailViewModel> GetUserDetailsByIdAsync(int userId)
        {
            var user = await _context.Users
                .Include(u => u.Departments)
                .Include(u => u.Manager)
                .Include(u => u.UserRoles)
                .ThenInclude (ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Id == userId && u.IsActive);

            if (user != null)
            {
                var colleagues = await _context.Users
                    .Where(u => u.ManagerID == user.ManagerID && u.Id != userId && u.IsActive)
                    .Select(u => new ManagerViewModel
                    {
                        Id = u.Id,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                    })
                    .ToListAsync();

                return new UserDetailViewModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    StartWorkDate = user.StartWorkDate,
                    EmailAddress = user.EmailAddress,
                    DepartmentName = user.Departments.Name,
                    ManagerId = user.ManagerID,
                    ManagerName = user.Manager != null ? $"{user.Manager.FirstName} {user.Manager.LastName}" : "Menajeri yok",
                    ManagerDepartmentName = user.Manager?.Departments?.Name,
                    IsActive = user.IsActive,
                    Role = user.UserRoles.Select(ur => ur.Role.Name).ToList(),
                    Colleagues = colleagues
                };
            }

            return null;
        }

        public async Task<List<UserViewModel>> GetAllUsersWithDetailsAsync()
        {
            var users = await _context.Users
                .Include(u => u.Departments)
                .Include(u => u.Manager)
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .ToListAsync();

            var userViewModels = users.Select(user => new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                StartWorkDate = user.StartWorkDate,
                EmailAddress = user.EmailAddress,
                DepartmentName = user.Departments.Name,
                ManagerName = user.Manager != null ? $"{user.Manager.FirstName} {user.Manager.LastName}" : "Menajeri yok",
                IsActive = user.IsActive,
                Role = user.UserRoles.Select(ur => ur.Role.Name).ToList()
            }).ToList();

            return userViewModels;
        }

        public async Task<List<ManagerViewModel>> GetSubordinatesAsync(int managerId)
        {
            var users = await _context.Users
                .Where(u => u.ManagerID == managerId && u.IsActive)
                .ToListAsync();
            var userViewModels = users.Select(user => new ManagerViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
            }).ToList();

            return userViewModels;
        }
    }
}