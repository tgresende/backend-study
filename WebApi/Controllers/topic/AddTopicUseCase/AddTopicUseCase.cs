using System;
using Microsoft.AspNetCore.Mvc;
using Apllication.useCases.topic.addTopicUseCase;
using System.Threading.Tasks;

namespace WebApi.Controllers.topic.AddTopicUseCase
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicController : ControllerBase
    {
        private readonly IAddTopicUseCase _useCase;

        public TopicController(IAddTopicUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpPost("AddTopic")]
        [ProducesResponseType(typeof(AddTopicUseCaseResponseModel), 200)]
        [ProducesResponseType(typeof(string), 422)]
         public async Task<IActionResult> Post([FromBody]AddTopicUseCaseRequestModel inputData)
        {
            try
            {
                var subject = await _useCase.Execute(inputData);
                return Ok(subject);
            }
            catch(Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }
    }
}