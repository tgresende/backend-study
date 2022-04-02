using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.entities;
using Domain.dtos.topic;
using Domain.interfaces;
using System.Linq;


namespace Apllication.useCases.topicCycle.addOptimizedTopicCycleUseCase
{
    public class AddOptimizedTopicCycleUseCase : IAddOptimizedTopicCycleUseCase
    {
        private readonly ITopicCycleRepository _topicCycleRepository;
        private readonly ITopicRepository _topicRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddOptimizedTopicCycleUseCase(ITopicCycleRepository topicCycleRepository,
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
            var topics = await _topicRepository.GetTopicsWithQuestions(subjectId);

            if (topics.Count == 0)
                throw new exceptions.topic.TopicsSubjectNotFoundException(MessageTopicsNotFound(subjectId));

            return topics;
        }

        private string MessageTopicsNotFound(int subjectId)
            => $"Topics of subjectId: {subjectId} not found.";

        private List<TopicCycle> GenerateTopicsCycle(List<Topic> topics)
        {
            var topicsDto = new List<TopicScoreInfoDTO>();

            foreach(Topic topic in topics)
            {
                topicsDto.Add(topic.CalcScore());
            }

            topicsDto.Sort((x, y) => y.Media.CompareTo(x.Media));

            var topicsCycle = new List<TopicCycle>();

            var countTopicsBCInserted = 0;

            foreach(TopicScoreInfoDTO dto in topicsDto)
            {
                if (countTopicsBCInserted == 2)
                    return topicsCycle;

                if (dto.Score == TopicCycleEnum.TopicCycleEnumScore.A)
                {
                    topicsCycle.Add(ConvertDtoToEntity(dto));
                    continue;
                }

                if (countTopicsBCInserted < 2)
                {
                    topicsCycle.Add(ConvertDtoToEntity(dto));
                    countTopicsBCInserted++;
                    continue;
                }
            }

            return topicsCycle;
        }

        private TopicCycle ConvertDtoToEntity(TopicScoreInfoDTO dto) =>
            new TopicCycle{
                Score = dto.Score,
                Status = TopicCycleEnum.TopicCycleEnumStatus.Ready,
                Topic = dto.topic,
            };

        private async Task PersistTopicsCycle(List<TopicCycle> topicsCycle)
        {
            foreach(TopicCycle cycleItem in topicsCycle)
            {
                await _topicCycleRepository.AddTopicCycle(cycleItem);
            }
        }


       


    }
}