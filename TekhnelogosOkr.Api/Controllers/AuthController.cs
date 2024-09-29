using Microsoft.AspNetCore.Mvc;
using System.Net;
using TekhnelogosOkr.Api.Controllers;
using TekhnelogosOkr.Business.Abstract;
using TekhnelogosOkr.Core.Utilities.Results;
using TekhnelogosOkr.ViewModel.Authentication;

namespace TekhnelogosOkr.API.Controllers
{
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginViewModel userLogin)
        {
            var result = await _authenticationService.Login(userLogin);

            if (result is SuccessDataResult<string> successResult)
            {
                return Ok(new { Token = successResult.Data, Message = successResult.Message });
            }
            else if (result is ErrorResult errorResult)
            {
                return StatusCode(errorResult.StatusCode, errorResult.Message);
            }

            return StatusCode((int)HttpStatusCode.InternalServerError, "İşlem hatası");
        }
    }
}