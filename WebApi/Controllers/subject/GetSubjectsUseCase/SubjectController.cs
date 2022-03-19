using Microsoft.AspNetCore.Mvc;
using Apllication.useCases.subject.getSubjectUseCase;
using System.Threading.Tasks;

namespace WebApi.Controllers.subject.GetSubjectsUseCase
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly IGetSubjectUseCase _useCase;

        public SubjectController(IGetSubjectUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpGet("GetSubjects/{projectId}")]
         public async Task<IActionResult> Get(int projectId)
        {
            var data = await _useCase.Execute(projectId);
            return Ok(data);
        }
    }
}