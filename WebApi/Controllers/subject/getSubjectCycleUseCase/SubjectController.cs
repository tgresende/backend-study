using Microsoft.AspNetCore.Mvc;
using Apllication.useCases.subject.getSubjectCycleUseCase;
using System.Threading.Tasks;

namespace WebApi.Controllers.subject.getSubjectCycleUseCase
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly IGetSubjectCycleUseCase _useCase;

        public SubjectController(IGetSubjectCycleUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpGet("GetSubjectCycle/{projectId}")]
         public async Task<IActionResult> Get(int projectId)
        {
            var data = await _useCase.Execute(projectId);
            return Ok(data);
        }
    }
}