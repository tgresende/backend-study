using System.Threading.Tasks;
namespace Apllication.useCases.question.addQuestionUseCase
{
    public interface IAddQuestionUseCase
    {
        public Task Execute(AddQuestionUseCaseRequestModel requestModel) ;
    }
}