using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.entities;
using Domain.interfaces;


namespace Apllication.useCases.topicCycle.addSimpleTopicCycleUseCase
{
    public class AddSimpleTopicCycleUseCase : IAddSimpleTopicCycleUseCase
    {
        private readonly ITopicCycleRepository _topicCycleRepository;
        private readonly ITopicRepository _topicRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddSimpleTopicCycleUseCase(ITopicCycleRepository topicCycleRepository,
            ITopicRepository topicRepository,
            IUnitOfWork unitOfWork)
        {
            _topicCycleRepository = topicCycleRepository;
            _topicRepository = topicRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(int subjectId)
        {
            var topics = await GetTopics(subjectId);

            var topicsCycle = GenerateTopicsCycle(topics);

            await PersistTopicsCycle(topicsCycle);

            await _unitOfWork.SaveChanges();
        }

        private async Task<List<Topic>> GetTopics(int subjectId)
        {
            var topics = await _topicRepository.GetTopics(subjectId);

            if (topics.Count == 0)
                throw new exceptions.topic.TopicsSubjectNotFoundException(MessageTopicsNotFound(subjectId));

            return topics;
        }

        private string MessageTopicsNotFound(int subjectId)
            => $"Topics of subjectId: {subjectId} not found.";

        private List<TopicCycle> GenerateTopicsCycle(List<Topic> topics)
        {
            var topicsCycle = new List<TopicCycle>();

            foreach(Topic topic in topics)
            {
                topicsCycle.Add(new TopicCycle{
                    Score = TopicCycleEnum.TopicCycleEnumScore.A,
                    Status = TopicCycleEnum.TopicCycleEnumStatus.Ready,
                    Topic = topic
                });

            }
            return topicsCycle;
        }

        private async Task PersistTopicsCycle(List<TopicCycle> topicsCycle)
        {
            foreach(TopicCycle cycleItem in topicsCycle)
            {
                await _topicCycleRepository.AddTopicCycle(cycleItem);
            }
        }


       


    }
}