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

        private readonly IUnitOfWork _unitOfWork;

        public AddQuestionUseCase(
            ISubjectRepository subjectRepository, 
            ITopicRepository topicRepository,
            IQuestionRepository questionRepository,
            IUnitOfWork unitOfWork)
        {
            _questionRepository = questionRepository;
            _topicRepository = topicRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(AddQuestionUseCaseRequestModel requestModel)
        {
            var topic = await GetTopic(requestModel.TopicId);

            var question = CreateNewQuestion(requestModel, topic);

            ValidateQuestion(question);

            await _questionRepository.AddQuestion(question);

            await _unitOfWork.SaveChanges();
        }

        private async Task<Topic> GetTopic(int topicId)
        {
            var topic = await _topicRepository.GetTopic(topicId);

            if (topic == null)
                throw new exceptions.topic.TopicNotFoundException($"Tópico: {topicId} não encontrado na base de dados.");

            return topic;
        }

        private Question CreateNewQuestion(AddQuestionUseCaseRequestModel requestModel, Topic topic) => 
            new Question{
                CorrectQuestions = requestModel.CorrectQuestions,
                DoneQuestions = requestModel.DoneQuestions,
                Topic = topic,
                Date = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()
            };
            

        private void ValidateQuestion(Question question)
        {
            if (!question.IsValid())
            {
                throw new exceptions.question.InvalidQuestionException("Questão com dados inválidos");
            }
        }
    }
}