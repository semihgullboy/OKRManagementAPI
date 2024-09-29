using Microsoft.AspNetCore.Mvc;
using TekhnelogosOkr.Business.Abstract;
using TekhnelogosOkr.Core.Utilities.Results;
using TekhnelogosOkr.ViewModel.Objective;

namespace TekhnelogosOkr.Api.Controllers
{
    [ApiController]
    public class OkrObjectiveController : BaseController
    {
        private readonly IOkrObjectiveService _objectiveService;

        public OkrObjectiveController(IOkrObjectiveService objectiveService)
        {
            _objectiveService = objectiveService;
        }

        [HttpPost("create")] //Normal kullanıcılar için Okr Ekleme İşlemi
        public async Task<IActionResult> CreateObjective([FromBody] AddOkrObjectiveViewModel objectiveViewModel)
        {
            var result = await _objectiveService.CreateObjectiveAsync(objectiveViewModel);

            if (result is ErrorResult errorResult)
            {
                return StatusCode(errorResult.StatusCode, new { message = errorResult.Message });
            }

            return Ok(new { message = result.Message });
        }

        [HttpPost("departmentObjectiveCreate")] // Departman Yöneticileri için Okr Ekleme İşlemi
        public async Task<IActionResult> CreateDepartmentObjective([FromBody] AddDepartmentOkrObjectiveViewModel objectiveViewModel)
        {
            var result = await _objectiveService.CreateDepartmanObjectiveAsync(objectiveViewModel);

            if (result is ErrorResult errorResult)
            {
                return StatusCode(errorResult.StatusCode, new { message = errorResult.Message });
            }

            return Ok(new { message = result.Message });
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OkrObjectiveViewModel))]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetOkrObjectivesByUserId([FromRoute] int userId)
        {
            var result = await _objectiveService.GetOkrObjectivesByUserIdAsync(userId);

            if (result is ErrorDataResult<OkrObjectiveViewModel> errorResult)
            {
                return StatusCode(errorResult.StatusCode, new { message = errorResult.Message });
            }

            return Ok(result.Data);
        }

        [HttpPut("{id}")] //Normal kullanıcılar için Okr Düzenleme İşlemi
        public async Task<IActionResult> UpdateObjective([FromBody] UpdateOkrObjectiveViewModel objectiveViewModel, [FromRoute] int id)
        {
            var result = await _objectiveService.UpdateOkrObjectiveAsync(objectiveViewModel, id);

            if (result is ErrorDataResult<OkrObjectiveViewModel> errorResult)
            {
                return StatusCode(errorResult.StatusCode, new { message = errorResult.Message });
            }

            return Ok(result.Message);
        }

        [HttpPut("departmentObjectivePut{id}")]  // Departman Yöneticileri için Okr Düzenleme İşlemi
        public async Task<IActionResult> UpdateDepartmentOkrObjective([FromBody] UpdateDepartmentOkrObjectiveViewModel objectiveViewModel, [FromRoute] int id)
        {
            var result = await _objectiveService.UpdateDepartmentOkrObjectiveAsync(objectiveViewModel, id);

            if (result is ErrorDataResult<OkrObjectiveViewModel> errorResult)
            {
                return StatusCode(errorResult.StatusCode, new { message = errorResult.Message });
            }

            return Ok(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObjective([FromRoute] int id)
        {
            var result = await _objectiveService.DeleteObjectiveAsync(id);

            if (result is ErrorResult errorResult)
            {
                return StatusCode(errorResult.StatusCode, new { message = errorResult.Message });
            }

            return Ok(result.Message);
        }
    }
}