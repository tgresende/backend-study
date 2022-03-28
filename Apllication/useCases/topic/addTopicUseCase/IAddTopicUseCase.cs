using System.Threading.Tasks;
namespace Apllication.useCases.topic.addTopicUseCase
{
    public interface IAddTopicUseCase
    {
        public Task<AddTopicUseCaseResponseModel> Execute(AddTopicUseCaseRequestModel requestModel) ;
    }
}