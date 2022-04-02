using System;
using Microsoft.AspNetCore.Mvc;
using Apllication.useCases.topicCycle.addOptimizedTopicCycleUseCase;
using System.Threading.Tasks;

namespace WebApi.Controllers.topicCycle.AddOptimizedTopicCycleUseCase
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicCycleController : ControllerBase
    {
        private readonly IAddOptimizedTopicCycleUseCase _useCase;

        public TopicCycleController(IAddOptimizedTopicCycleUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpPost("AddOptimizedTopicsCycle/{subjectId}")]
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