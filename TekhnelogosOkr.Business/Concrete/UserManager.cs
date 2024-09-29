using AutoMapper;
using System.Net;
using TekhnelogosOkr.Business.Abstract;
using TekhnelogosOkr.Business.Constants;
using TekhnelogosOkr.Common.Enum;
using TekhnelogosOkr.Core.Utilities.Results;
using TekhnelogosOkr.DataAccess.Abstract;
using TekhnelogosOkr.Entity.Concrete;
using TekhnelogosOkr.Entity.Concrete.TekhnelogosOkr.Entity.Concrete;
using TekhnelogosOkr.ViewModel.User;

namespace TekhnelogosOkr.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRoleDal _roleDal;

        public UserManager(IUserDal userDal, IMapper mapper, IUnitOfWork unitOfWork, IUserRoleDal roleDal)
        {
            _userDal = userDal;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _roleDal = roleDal;
        }

        public async Task<IResult> LdapCreateUserAsync(LdapUserViewModel userViewModel)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var user = _mapper.Map<User>(userViewModel);
                user.CreatedDate = DateTime.Now;
                user.UpdatedDate = DateTime.Now;
                await _userDal.AddAsync(user);

                var UserRole = new UserRole
                {
                    UserId = user.Id,
                    RoleId = (int)EnumRole.User,
                    IsActive = user.IsActive,
                };

                await _roleDal.AddAsync(UserRole);

                await _unitOfWork.CommitTransactionAsync();
                return new SuccessResult(Messages.UserAdded);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return new ErrorResult(Messages.UserAddedFailed, (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IResult> DeactivateUserAsync(int id, UpdateUserViewModel userActiveViewModel)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var user = await _userDal.GetAsync(u => u.Id == id);
                if (user == null)
                {
                    return new ErrorResult(Messages.UserNotFound, (int)HttpStatusCode.NotFound);
                }

                user.IsActive = userActiveViewModel.IsActive;
                await _userDal.UpdateAsync(user);

                var userRole = await _roleDal.GetAsync(ur => ur.UserId == id);
                if (userRole != null)
                {
                    userRole.RoleId = userActiveViewModel.RoleId;
                    userRole.IsActive = user.IsActive;
                    await _roleDal.UpdateAsync(userRole);
                }
                else
                {
                    return new ErrorResult(Messages.UserRoleNotFound, (int)HttpStatusCode.NotFound);
                }

                await _unitOfWork.CommitTransactionAsync();

                return new SuccessResult(Messages.UserDeactivated);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return new ErrorResult(Messages.UserDeactivationFailed, (int)HttpStatusCode.InternalServerError);
            }
        }



        public async Task<IDataResult<List<UserViewModel>>> GetAllDetailUsersAsync()
        {
            try
            {
                var users = await _userDal.GetAllUsersWithDetailsAsync();
                var usersViewModel = _mapper.Map<List<UserViewModel>>(users);
                return new SuccessDataResult<List<UserViewModel>>(usersViewModel, Messages.UsersListed);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<UserViewModel>>(Messages.UserListedFailed, (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IDataResult<UserDetailViewModel>> GetUserDetailByIdAsync(int id)
        {
            try
            {
                var user = await _userDal.GetUserDetailsByIdAsync(id);
                if (user == null)
                {
                    return new ErrorDataResult<UserDetailViewModel>(Messages.UserNotFound, (int)HttpStatusCode.NotFound);
                }
                var userViewModel = _mapper.Map<UserDetailViewModel>(user);
                return new SuccessDataResult<UserDetailViewModel>(userViewModel, Messages.UserListed);
            }
            catch (Exception)
            {
                return new ErrorDataResult<UserDetailViewModel>(Messages.UserListedFailed, (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IDataResult<List<ManagerViewModel>>> GetSubordinatesAsync(int managerId)
        {
            try
            {
                var subordinates = await _userDal.GetSubordinatesAsync(managerId);
                if (subordinates == null)
                {
                    return new ErrorDataResult<List<ManagerViewModel>>(Messages.UserNotFound, (int)HttpStatusCode.NotFound);
                }
                var usersViewModel = _mapper.Map<List<ManagerViewModel>>(subordinates);
                return new SuccessDataResult<List<ManagerViewModel>>(usersViewModel, Messages.UserListed);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<ManagerViewModel>>(Messages.UserListedFailed, (int)HttpStatusCode.InternalServerError);
            }
        }

        // User tablosunda menajerin mailine göre managerId eklemek için 
        public async Task<int?> GetManagerIdByEmailAsync(string email)
        {
            var user = await _userDal.GetAsync(u => u.EmailAddress == email);
            return user?.Id;
        }

        // Ldaptan tekrar güncelleme yapıldığı zaman kullanıcın varlığını kontrol etmek için
        public async Task<LdapUserViewModel> GetUserByEmailAsync(string emailAddress)
        {
            var user = await _userDal.GetAsync(u => u.EmailAddress == emailAddress);
            return _mapper.Map<LdapUserViewModel>(user);
        }

        public async Task<IResult> LdapUpdateUserAsync(LdapUserViewModel userViewModel)
        {
            try
            {
                var user = await _userDal.GetAsync(u => u.EmailAddress == userViewModel.EmailAddress);
                if (user == null)
                {
                    return new ErrorResult(Messages.UserNotFound, (int)HttpStatusCode.NotFound);
                }

                user.FirstName = userViewModel.FirstName;
                user.LastName = userViewModel.LastName;
                user.StartWorkDate = userViewModel.StartWorkDate;
                user.ManagerID = userViewModel.ManagerID;
                user.DepartmentID = userViewModel.DepartmentID;
                user.UpdatedDate = DateTime.Now;

                await _userDal.UpdateAsync(user);

                return new SuccessResult(Messages.UserUpdated);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.UserUpdatedFailed, (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<string> GetUserRoleAsync(int userId)
        {
            var userRole = await _userDal.GetUserRoleNameAsync(userId);
            return userRole;
        }
    }
}