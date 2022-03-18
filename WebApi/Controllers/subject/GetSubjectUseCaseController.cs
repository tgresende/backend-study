using Microsoft.AspNetCore.Mvc;
using Apllication.useCases.subject.getSubjectUseCase;
using System.Threading.Tasks;

namespace WebApi.Controllers.subject
{
    [ApiController]
    [Route("[controller]")]
    public class GetSubjectUseCaseController : ControllerBase
    {
        private readonly IGetSubjectUseCase _useCase;

        public GetSubjectUseCaseController(IGetSubjectUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpGet("GetSubjectsFromProject/{projectId}")]
         public async Task<IActionResult> Get(int projectId)
        {
            var data = await _useCase.Execute(projectId);
            return Ok(data);
        }
    }
}