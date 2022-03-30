using System;
using Microsoft.AspNetCore.Mvc;
using Apllication.useCases.subject.addSimpleSubjectCycleUseCase;
using System.Threading.Tasks;

namespace WebApi.Controllers.subject.addSimpleSubjectCycleUseCase
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly IAddSimpleSubjectCycleUseCase _useCase;

        public SubjectController(IAddSimpleSubjectCycleUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpPost("AddSimpleSubjectCycle/{projectId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 422)]
        public async Task<IActionResult> Post(int projectId)
        {
            try
            {
                await _useCase.Execute(projectId);
                return Ok();
            }
            catch(Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }
    }
}