using System;
using Microsoft.AspNetCore.Mvc;
using Apllication.useCases.topicCycle.addSimpleTopicCycleUseCase;
using System.Threading.Tasks;

namespace WebApi.Controllers.topicCycle.AddSimpleTopicCycleUseCase
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicCycleController : ControllerBase
    {
        private readonly IAddSimpleTopicCycleUseCase _useCase;

        public TopicCycleController(IAddSimpleTopicCycleUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpPost("AddSimpleTopicsCycle/{subjectId}")]
        [ProducesResponseType(200)]
         public async Task<IActionResult> Post(int subjectId)
        {
           try
            {
                await _useCase.Execute(subjectId);
                return Ok();
            }
            catch(Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }
    }
}