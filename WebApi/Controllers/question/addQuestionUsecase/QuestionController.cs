using System;
using Microsoft.AspNetCore.Mvc;
using Apllication.useCases.question.addQuestionUseCase;
using System.Threading.Tasks;

namespace WebApi.Controllers.question.addQuestionUseCase
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly IAddQuestionUseCase _useCase;

        public QuestionController(IAddQuestionUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpPost("AddQuestionUseCase")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 422)]
        public async Task<IActionResult> Post([FromBody] AddQuestionUseCaseRequestModel requestModel)
        {
            try
            {
                await _useCase.Execute(requestModel);
                return Ok();
            }
            catch(Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }
    }
}