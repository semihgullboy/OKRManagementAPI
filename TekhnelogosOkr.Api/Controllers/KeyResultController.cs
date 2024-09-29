using Microsoft.AspNetCore.Mvc;
using System.Net;
using TekhnelogosOkr.Business.Abstract;
using TekhnelogosOkr.Core.Utilities.Results;
using TekhnelogosOkr.ViewModel.KeyResult;

namespace TekhnelogosOkr.Api.Controllers
{

    [ApiController]
    public class KeyResultController : BaseController
    {
        private readonly IKeyResultService _keyResultService;

        public KeyResultController(IKeyResultService keyResultService)
        {
            _keyResultService = keyResultService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateIndividualKeyResult([FromBody] AddKeyResultViewModel keyResultViewModel)
        {
            var result = await _keyResultService.CreateKeyResultAsync(keyResultViewModel);

            if (result is ErrorResult errorResult)
            {
                return StatusCode(errorResult.StatusCode, new { message = errorResult.Message });
            }

            return Ok(new { data = result.Data, message = result.Message });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> KeyResultDelete([FromRoute] int id)
        {
            var result = await _keyResultService.DeleteKeyResultAsync(id);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, result.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> KeyResultUpdate(UpdateKeyResultViewModel keyResultViewModel, [FromRoute] int id)
        {
            var result = await _keyResultService.UpdateKeyResultAsync(keyResultViewModel, id);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, result.Message);
            }
        }
    }
}