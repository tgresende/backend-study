using System.Threading.Tasks;
using Domain.interfaces;
using Domain.entities;
using Apllication.services.topic;

namespace Apllication.useCases.topic.addTopicUseCase
{
    public class AddTopicUseCase : IAddTopicUseCase
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly ITopicRepository _topicRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddTopicUseCase(ISubjectRepository subjectRepository, ITopicRepository topicRepository,
        IUnitOfWork unitOfWork)
        {
            _subjectRepository = subjectRepository;
            _topicRepository = topicRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AddTopicUseCaseResponseModel> Execute(AddTopicUseCaseRequestModel requestModel)
        {
            var subject = await _subjectRepository.GetSubject(requestModel.SubjectId);

            var topic = new Topic(){
                Annotations = requestModel.Annotations,
                Name = requestModel.Name,
                Subject = subject
            };

            ValidateTopic(topic);

            await _topicRepository.AddTopic(topic);

            await _unitOfWork.SaveChanges();

            return ParseToResponseModel(topic);
        }

        private void ValidateTopic(Topic topic)
        {
            if (!topic.IsValid())
            {
                throw new exceptions.InvalidSubjectException(TopicService.GetInvalidTopicProperties(topic));
            }
        }

        private AddTopicUseCaseResponseModel ParseToResponseModel(Topic topic) =>
            new AddTopicUseCaseResponseModel(){
                Annotations = topic.Annotations,
                Name = topic.Name,
                SubjectId = topic.Subject.SubjectId
            };

    }
}