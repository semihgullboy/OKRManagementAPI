using AutoMapper;
using System.Net;
using TekhnelogosOkr.Business.Abstract;
using TekhnelogosOkr.Business.Constants;
using TekhnelogosOkr.Core.Utilities.Results;
using TekhnelogosOkr.DataAccess.Abstract;
using TekhnelogosOkr.Entity.Concrete;
using TekhnelogosOkr.ViewModel.Department;

namespace TekhnelogosOkr.Business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentDal _departmentDal;
        private readonly IMapper _mapper;

        public DepartmentManager(IDepartmentDal departmentDal, IMapper mapper)
        {
            _departmentDal = departmentDal;
            _mapper = mapper;
        }

        public async Task<IResult> CreateDepartmentAsync(DepartmentViewModel departmentViewModel)
        {
            try
            {
                var department = _mapper.Map<Department>(departmentViewModel);
                department.CreatedDate = DateTime.Now;
                department.UpdatedDate = DateTime.Now;
                department.IsActive = true;
                await _departmentDal.AddAsync(department);

                return new SuccessResult(Messages.DepartmentAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Bir hata oluştu: {ex.Message}", (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IResult> LdapUpdateDepartmentAsync(DepartmentViewModel departmentViewModel)
        {
            try
            {
                var department = await _departmentDal.GetAsync(u => u.Name == departmentViewModel.Name);
                if (department == null)
                {
                    return new ErrorResult(Messages.DepartmentNotFound, (int)HttpStatusCode.NotFound);
                }

                department.Name = departmentViewModel.Name;
                department.UpdatedDate = DateTime.Now;

                await _departmentDal.UpdateAsync(department);

                return new SuccessResult(Messages.DepartmentUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Güncelleme sırasında bir hata oluştu: {ex.Message}", (int)HttpStatusCode.InternalServerError);
            }
        }

        // User tablosunda departmanId eklemek için 
        public async Task<int?> GetDepartmentIdByNameAsync(string departmentName)
        {
            var department = await _departmentDal.GetAsync(d => d.Name == departmentName);
            return department?.Id;
        }

        // Claimse departman yönetici olup olmadığını eklemek için
        public async Task<bool> IsUserDepartmentManagerAsync(int id)
        {
            var departmentmanager = await _departmentDal.GetAsync(d => d.DepartmentManagerID == id);
            return departmentmanager != null;
        }
    }
}