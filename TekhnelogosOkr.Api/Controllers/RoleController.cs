using Microsoft.AspNetCore.Mvc;
using TekhnelogosOkr.Business.Abstract;
using TekhnelogosOkr.ViewModel.Role;

namespace TekhnelogosOkr.Api.Controllers
{
    [ApiController]
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RoleViewModel))]
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var result = await _roleService.GetAllRolesAsync();

            if (result.Success)
            {
                return Ok(new
                {
                    result.Message,
                    result.Data
                });
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}
