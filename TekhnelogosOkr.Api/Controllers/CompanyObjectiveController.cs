using Microsoft.AspNetCore.Mvc;
using TekhnelogosOkr.Api.Controllers;
using TekhnelogosOkr.Business.Abstract;
using TekhnelogosOkr.Core.Utilities.Results;
using TekhnelogosOkr.ViewModel.CompanyObjective;


namespace TekhnelogosOkr.WebApi.Controllers
{

    [ApiController]
    public class CompanyObjectiveController : BaseController
    {
        private readonly ICompanyObjectiveService _companyObjectiveService;

        public CompanyObjectiveController(ICompanyObjectiveService companyObjectiveService)
        {
            _companyObjectiveService = companyObjectiveService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> CreateCompanyObjective([FromBody] AddCompanyObjectiveViewModel companyObjectiveViewModel)
        {
            var result = await _companyObjectiveService.CreateCompanyObjectiveAsync(companyObjectiveViewModel);

            if (result is ErrorResult errorResult)
            {
                return StatusCode(errorResult.StatusCode, new { message = errorResult.Message });
            }

            return Ok(new { message = result.Message });
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompanyObjectiveViewModel))]
        [HttpGet]
        public async Task<IActionResult> GetAllCompanyObjectives()
        {
            var result = await _companyObjectiveService.GetAllCompanyObjectivesAsync();

            if (result is ErrorDataResult<List<CompanyObjectiveViewModel>> errorResult)
            {
                return StatusCode(errorResult.StatusCode, new { Message = errorResult.Message });
            }

            return Ok(result.Data);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompanyObjectiveDetailViewModel))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyObjectiveWithOkrObjectives([FromRoute] int id)
        {
            var result = await _companyObjectiveService.GetCompanyObjectiveWithOkrObjectivesAsync(id);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return NotFound(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompanyObjective([FromBody] UpdateCompanyObjectiveViewModel companyObjectiveViewModel, [FromRoute] int id)
        {
            var result = await _companyObjectiveService.UpdateCompanyObjectiveAsync(companyObjectiveViewModel, id);

            if (result is ErrorDataResult<CompanyObjectiveViewModel> errorResult)
            {
                return StatusCode(errorResult.StatusCode, new { message = errorResult.Message });
            }

            return Ok(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyObjective([FromRoute] int id)
        {
            var result = await _companyObjectiveService.DeleteCompanyObjectiveAsync(id);

            if (result is ErrorResult errorResult)
            {
                return StatusCode(errorResult.StatusCode, new { message = errorResult.Message });
            }

            return Ok(result.Message);
        }
    }
}