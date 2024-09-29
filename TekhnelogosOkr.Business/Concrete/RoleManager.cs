using AutoMapper;
using System.Net;
using TekhnelogosOkr.Business.Abstract;
using TekhnelogosOkr.Business.Constants;
using TekhnelogosOkr.Core.Utilities.Results;
using TekhnelogosOkr.DataAccess.Abstract;
using TekhnelogosOkr.ViewModel.Role;

namespace TekhnelogosOkr.Business.Concrete
{
    public class RoleManager : IRoleService
    {
        private readonly IRoleDal _roleDal;
        private readonly IMapper _mapper;

        public RoleManager(IRoleDal roleDal, IMapper mapper)
        {
            _roleDal = roleDal;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<RoleViewModel>>> GetAllRolesAsync()
        {
            try
            {
                var role = await _roleDal.GetAllAsync();
                var roles = _mapper.Map<List<RoleViewModel>>(role);
                return new SuccessDataResult<List<RoleViewModel>>(roles, Messages.RolesListed);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<RoleViewModel>>("Bir hata oluştu: " + ex.Message, (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
