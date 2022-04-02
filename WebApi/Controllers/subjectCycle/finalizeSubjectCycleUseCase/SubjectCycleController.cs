using System;
using Microsoft.AspNetCore.Mvc;
using Apllication.useCases.subjectCycle.finalizeSubjectCycleUseCase;
using System.Threading.Tasks;

namespace WebApi.Controllers.subjectCycle.finalizeSubjectCycleUseCase
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectCycleController : ControllerBase
    {
        private readonly IFinalizeSubjectCycleUseCase _useCase;

        public SubjectCycleController(IFinalizeSubjectCycleUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpPost("FinalizeSubjectCycle/{subjectCycleId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 422)]
        public async Task<IActionResult> Post(int subjectCycleId)
        {
            try
            {
                await _useCase.Execute(subjectCycleId);
                return Ok();
            }
            catch(Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }
    }
}