using Microsoft.AspNetCore.Mvc;
using TekhnelogosOkr.Api.Controllers;
using TekhnelogosOkr.Business.Abstract;
using TekhnelogosOkr.Core.Utilities.Results;
using TekhnelogosOkr.ViewModel.KeyResultTransaction;

namespace TekhnelogosOkr.WebApi.Controllers
{
    [ApiController]
    public class KeyResultTransactionController : BaseController
    {
        private readonly IKeyResultTransactionService _keyResultTransactionService;

        public KeyResultTransactionController(IKeyResultTransactionService keyResultTransactionService)
        {
            _keyResultTransactionService = keyResultTransactionService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateKeyResultTransaction([FromBody] AddKeyResultTransactionViewModel addKeyResultTransaction)
        {
            var result = await _keyResultTransactionService.CreateKeyResultTransaction(addKeyResultTransaction);
            
            if (result is ErrorResult errorResult)
            {
                return StatusCode(errorResult.StatusCode, new { message = errorResult.Message });
            }

            return Ok(new { message = result.Message });
        }
    }
}
