using Microsoft.AspNetCore.Mvc;
using TekhnelogosOkr.Business.Abstract;
using TekhnelogosOkr.ViewModel.User;

namespace TekhnelogosOkr.Api.Controllers
{
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserViewModel))]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetAllDetailUsersAsync();

            if (result.Success)
            {
                return Ok(new
                {
                    Message = result.Message,
                    Data = result.Data
                });
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDetailViewModel))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserDetail([FromRoute] int id)
        {
            var result = await _userService.GetUserDetailByIdAsync(id);

            if (result.Success)
            {
                return Ok(new
                {
                    Message = result.Message,
                    Data = result.Data
                });
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ManagerViewModel))]
        [HttpGet("subordinates/{id}")] // Kullanıcın altında çalışan kişileri listelemek için
        public async Task<IActionResult> GetSubordinates([FromRoute] int id)
        {
            var result = await _userService.GetSubordinatesAsync(id);
            if (result.Success)
            {
                return Ok(new
                {
                    Message = result.Message,
                    Data = result.Data
                });
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPut("{id}")] //Kullanıcın rolünü ve aktifliğini düzenlemek için
        public async Task<IActionResult> DeactivateUser([FromRoute] int id, UpdateUserViewModel userActiveViewModel)
        {
            var result = await _userService.DeactivateUserAsync(id, userActiveViewModel);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }


    }
}