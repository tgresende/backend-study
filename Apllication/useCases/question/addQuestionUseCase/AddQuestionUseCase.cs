using System;
using System.Threading.Tasks;
using Domain.interfaces;
using Domain.entities;

namespace Apllication.useCases.question.addQuestionUseCase
{
    public class AddQuestionUseCase : IAddQuestionUseCase
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly ITopicCycleRepository _topicCycleRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AddQuestionUseCase(
            ISubjectRepository subjectRepository, 
            ITopicRepository topicRepository,
            ITopicCycleRepository topicCycleRepository,
            IQuestionRepository questionRepository,
            IUnitOfWork unitOfWork)
        {
            _questionRepository = questionRepository;
            _topicRepository = topicRepository;
            _topicCycleRepository = topicCycleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(AddQuestionUseCaseRequestModel requestModel)
        {
            var topic = await GetTopic(requestModel.TopicId);

            var question = CreateNewQuestion(requestModel, topic);

            ValidateQuestion(question);

            var topicCycle = await GetTopicCycle(requestModel.TopicCycleId);

            var topicUpdated = UpdateTopic(topic, requestModel);

            await _questionRepository.AddQuestion(question);

            topicCycle.Status = TopicCycleEnum.TopicCycleEnumStatus.Done;

            await _unitOfWork.SaveChanges();
        }

        private async Task<Topic> GetTopic(int topicId)
        {
            var topic = await _topicRepository.GetTopic(topicId);

            if (topic == null)
                throw new exceptions.topic.TopicNotFoundException($"Tópico: {topicId} não encontrado na base de dados.");

            return topic;
        }

        private async Task<TopicCycle> GetTopicCycle(int topicCycleId)
        {
            var topicCycle = await _topicCycleRepository.GetTopicCycle(topicCycleId);

            if (topicCycle == null)
                throw new exceptions.topicCycle.TopicCycleNotFoundException($"Item de Ciclo de Tópico: {topicCycleId} não encontrado na base de dados.");

            return topicCycle;
        }

        private Question CreateNewQuestion(AddQuestionUseCaseRequestModel requestModel, Topic topic) => 
            new Question{
                CorrectQuestions = requestModel.CorrectQuestions,
                DoneQuestions = requestModel.DoneQuestions,
                Topic = topic,
                Date = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(),
            };
            

        private void ValidateQuestion(Question question)
        {
            if (!question.IsValid())
            {
                throw new exceptions.question.InvalidQuestionException("Questão com dados inválidos");
            }
        }

        private Topic UpdateTopic(Topic topic, AddQuestionUseCaseRequestModel requestModel)
        {
            var updatedTopic = topic;

            updatedTopic.lawsCycle = requestModel.lawsCycle;
            updatedTopic.lawsItem = requestModel.lawsItem;
            updatedTopic.readingCycle = requestModel.readingCycle;
            updatedTopic.readingItem = requestModel.readingItem;
            updatedTopic.revisionCycle = requestModel.revisionCycle;
            updatedTopic.revisionItem = requestModel.revisionItem;

            return updatedTopic;
        }
    }
}