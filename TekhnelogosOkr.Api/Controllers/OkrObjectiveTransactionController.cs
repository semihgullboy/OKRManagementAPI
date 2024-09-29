using Microsoft.AspNetCore.Mvc;
using TekhnelogosOkr.Api.Controllers;
using TekhnelogosOkr.Business.Abstract;
using TekhnelogosOkr.Core.Utilities.Results;
using TekhnelogosOkr.ViewModel.CompanyObjective;
using TekhnelogosOkr.ViewModel.Objective;
using TekhnelogosOkr.ViewModel.OkrObjectiveTransaction;

namespace TekhnelogosOkr.WebAPI.Controllers
{
    [ApiController]
    public class OkrObjectiveTransactionController : BaseController
    {
        private readonly IOkrObjectiveTransactionService _okrObjectiveTransactionService;

        public OkrObjectiveTransactionController(IOkrObjectiveTransactionService okrObjectiveTransactionService)
        {
            _okrObjectiveTransactionService = okrObjectiveTransactionService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateOkrObjectiveTransaction([FromBody] AddOkrObjectiveTransactionViewModel okrObjectiveTransactionViewModel)
        {
            var result = await _okrObjectiveTransactionService.CreateOkrObjectiveTransaction(okrObjectiveTransactionViewModel);

            if (result is ErrorResult errorResult)
            {
                return StatusCode(errorResult.StatusCode, new { message = errorResult.Message });
            }

            return Ok(new { message = result.Message });
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompanyObjectiveViewModel))]
        [HttpGet("{okrObjectiveId}")]
        public async Task<IActionResult> GetOkrObjectiveTransactions([FromRoute] int okrObjectiveId)
        {
            var result = await _okrObjectiveTransactionService.GetOkrObjectiveTransactionAsync(okrObjectiveId);

            if (result is ErrorDataResult<List<CompanyObjectiveViewModel>> errorResult)
            {
                return StatusCode(errorResult.StatusCode, new { message = errorResult.Message });
            }

            return Ok(result.Data);
        }
    }
}
