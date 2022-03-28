using Microsoft.AspNetCore.Mvc;
using Apllication.useCases.topic.getSubjectTopicsUseCase;
using System.Threading.Tasks;

namespace WebApi.Controllers.topic.GetSubjectTopicsUseCase
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicController : ControllerBase
    {
        private readonly IGetSubjectTopicsUseCase _useCase;

        public TopicController(IGetSubjectTopicsUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpGet("GetSubjectTopics/{subjectId}")]
        [ProducesResponseType(typeof(GetSubjectTopicsUseCaseResponseModel), 200)]
         public async Task<IActionResult> Post(int subjectId)
        {
            var subject = await _useCase.Execute(subjectId);
            return Ok(subject);
        }
    }
}