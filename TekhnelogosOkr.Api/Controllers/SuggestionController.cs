using Microsoft.AspNetCore.Mvc;
using System.Net;
using TekhnelogosOkr.Business.Abstract;
using TekhnelogosOkr.Core.Utilities.Results;
using TekhnelogosOkr.ViewModel.Suggestion;

namespace TekhnelogosOkr.Api.Controllers
{
    [ApiController]
    public class SuggestionController : BaseController
    {
        private readonly ISuggestionService _suggestionService;

        public SuggestionController(ISuggestionService suggestionService)
        {
            _suggestionService = suggestionService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> CreateSuggestions([FromBody] AddSuggestionViewModel suggestionViewModel)
        {
            var result = await _suggestionService.CreateSuggestionAsync(suggestionViewModel);

            if (result is ErrorResult errorResult)
            {
                return StatusCode(errorResult.StatusCode, new { message = errorResult.Message });
            }

            return Ok(new { message = result.Message });
        }

        [HttpPost("approve/{suggestionId}")] //Bekleyen Okr Kabul etme işlemi
        public async Task<IActionResult> ApproveSuggestion([FromRoute] int suggestionId)
        {
            var result = await _suggestionService.ApproveSuggestionAsync(suggestionId);

            if (result is SuccessResult)
            {
                return Ok(result);
            }

            return StatusCode((int)HttpStatusCode.BadRequest, result);
        }

        [HttpDelete("{Id}")] //Bekleyen Okr Red etme işlemi
        public async Task<IActionResult> DeclineSuggestion([FromRoute] int Id)
        {
            var result = await _suggestionService.DeclineSuggestionAsync(Id);

            if (result is ErrorResult errorResult)
            {
                return StatusCode(errorResult.StatusCode, new { message = errorResult.Message });
            }

            return Ok(new { message = result.Message });
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuggestionDetailsViewModel))]
        [HttpGet("{receiverId}")]
        public async Task<IActionResult> GetSuggestionDetails([FromRoute] int receiverId)
        {
            var result = await _suggestionService.GetSuggestionDetailsAsync(receiverId);

            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return NotFound(result.Message);
            }
        }
    }
}
