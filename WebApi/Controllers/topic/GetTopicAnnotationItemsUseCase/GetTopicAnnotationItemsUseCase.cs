using Microsoft.AspNetCore.Mvc;
using Apllication.useCases.topic.getTopicAnnotationItemsUseCase;
using System.Threading.Tasks;

namespace WebApi.Controllers.topic.GetTopicAnnotationItemsUseCase
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicController : ControllerBase
    {
        private readonly IGetTopicAnnotationItemsUseCase _useCase;

        public TopicController(IGetTopicAnnotationItemsUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpGet("GetTopicAnnotation/{topicId}")]
        [ProducesResponseType(typeof(GetTopicAnnotationItemsUseCaseResponseModel), 200)]
         public async Task<IActionResult> Get(int topicId)
        {
            var topic = await _useCase.Execute(topicId);
            return Ok(topic);
        }
    }
}