using System;
using Microsoft.AspNetCore.Mvc;
using Apllication.useCases.subject.addSubjectUseCase;
using System.Threading.Tasks;

namespace WebApi.Controllers.subject.AddSubjectUseCase
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly IAddSubjectUseCase _useCase;

        public SubjectController(IAddSubjectUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpPost("AddSubject")]
        [ProducesResponseType(typeof(AddSubjectUseCaseResponseModel), 200)]
        [ProducesResponseType(typeof(string), 422)]
         public async Task<IActionResult> Post([FromBody]AddSubjectUseCaseRequestModel inputData)
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