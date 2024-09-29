using TekhnelogosOkr.Core.Utilities.Results;
using TekhnelogosOkr.ViewModel.Role;

namespace TekhnelogosOkr.Business.Abstract
{
    public interface IRoleService
    {
        Task<IDataResult<List<RoleViewModel>>> GetAllRolesAsync();
    }
}
