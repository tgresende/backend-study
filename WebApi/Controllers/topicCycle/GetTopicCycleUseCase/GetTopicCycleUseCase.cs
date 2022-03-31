using Microsoft.AspNetCore.Mvc;
using Apllication.useCases.topicCycle.getTopicCycleUseCase;
using System.Threading.Tasks;

namespace WebApi.Controllers.topicCycle.GetTopicCycleUseCase
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicCycleController : ControllerBase
    {
        private readonly IGetTopicCycleUseCase _useCase;

        public TopicCycleController(IGetTopicCycleUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpGet("GetTopicsCycle/{subjectId}")]
        [ProducesResponseType(typeof(GetTopicCycleUseCaseResponseModel), 200)]
         public async Task<IActionResult> Get(int subjectId)
        {
            var topicsCycle = await _useCase.Execute(subjectId);
            return Ok(topicsCycle);
        }
    }
}