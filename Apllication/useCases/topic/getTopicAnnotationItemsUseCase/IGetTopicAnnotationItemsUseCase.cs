using System.Threading.Tasks;
namespace Apllication.useCases.topic.getTopicAnnotationItemsUseCase
{
    public interface IGetTopicAnnotationItemsUseCase
    {
        public Task<GetTopicAnnotationItemsUseCaseResponseModel> Execute(int topicId) ;
    }
}