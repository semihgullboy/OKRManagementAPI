using Microsoft.AspNetCore.Mvc;
using TekhnelogosOkr.Api.Controllers;
using TekhnelogosOkr.Business.Abstract;
using TekhnelogosOkr.ViewModel.Status;

namespace TekhnelogosOkr.WebAPI.Controllers
{
    [ApiController]
    public class StatusController : BaseController
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StatusViewModel))]
        [HttpGet]
        public async Task<IActionResult> GetAllStatuses()
        {
            var result = await _statusService.GetAllStatusesAsync();

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