using TekhnelogosOkr.Core.Utilities.Results;
using TekhnelogosOkr.ViewModel.Department;

namespace TekhnelogosOkr.Business.Abstract
{
    public interface IDepartmentService
    {
        Task<IResult> CreateDepartmentAsync(DepartmentViewModel departmentViewModel);

        Task<int?> GetDepartmentIdByNameAsync(string departmentName);

        Task<bool> IsUserDepartmentManagerAsync(int id);

        Task<IResult> LdapUpdateDepartmentAsync(DepartmentViewModel departmentViewModel);
    }
}