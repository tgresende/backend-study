using System.Threading.Tasks;
using Domain.interfaces;
using Domain.entities;
using Apllication.services.topic;

namespace Apllication.useCases.topic.getTopicAnnotationItemsUseCase
{
    public class GetTopicAnnotationItemsUseCase : IGetTopicAnnotationItemsUseCase
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly ITopicRepository _topicRepository;
        public GetTopicAnnotationItemsUseCase(
            ISubjectRepository subjectRepository, 
            ITopicRepository topicRepository
        )
        {
            _subjectRepository = subjectRepository;
            _topicRepository = topicRepository;
        }

        public async Task<GetTopicAnnotationItemsUseCaseResponseModel> Execute(int topicId)
        {
            var topic = await GetTopic(topicId);

            var subject = await GetSubject(topic.Subject.SubjectId);

            return ParseToResponseModel(topic, subject);
        }

        private async Task<Topic> GetTopic(int topicId)
        {
            var topic = await _topicRepository.GetTopic(topicId);
            if (topic==null)
            {
                throw new exceptions.topic.TopicNotFoundException($"Tópico: {topicId} náo encontrado na base de dados");
            }
            return topic;
        }

        private async Task<Subject> GetSubject(int subjectId)
        {
            var subject = await _subjectRepository.GetSubject(subjectId);
            if (subject==null)
            {
                throw new exceptions.topic.TopicNotFoundException($"Assunto: {subjectId} náo encontrado na base de dados");
            }
            return subject;
        }

        private void ValidateTopic(Topic topic)
        {
            if (!topic.IsValid())
            {
                throw new exceptions.InvalidSubjectException(TopicService.GetInvalidTopicProperties(topic));
            }
        }



        private GetTopicAnnotationItemsUseCaseResponseModel ParseToResponseModel(Topic topic, Subject subject) =>
            new GetTopicAnnotationItemsUseCaseResponseModel(){
                Annotations = topic.Annotations,
                Name = topic.Name,
                SubjectId = topic.Subject.SubjectId,
                lawsCycle = topic.lawsCycle,
                lawsItem = topic.lawsItem,
                readingCycle = topic.readingCycle,
                readingItem = topic.readingItem,
                revisionCycle = topic.revisionCycle,
                revisionItem = topic.revisionItem,
                TopicId = topic.TopicId
            };

    }
}