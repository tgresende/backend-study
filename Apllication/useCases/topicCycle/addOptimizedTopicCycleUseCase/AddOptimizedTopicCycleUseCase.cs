using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.entities;
using Domain.dtos.topic;
using Domain.interfaces;
using Domain.enums;
using System.Linq;


namespace Apllication.useCases.topicCycle.addOptimizedTopicCycleUseCase
{
    public class AddOptimizedTopicCycleUseCase : IAddOptimizedTopicCycleUseCase
    {
        private readonly ITopicCycleRepository _topicCycleRepository;
        private readonly ITopicRepository _topicRepository;
        private readonly IUnitOfWork _unitOfWork;

        private const int periodToCalcScoreQuestionInDays = 15;

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
                topicsDto.Add(topic.CalcScore(periodToCalcScoreQuestionInDays));
            }

            var listScoreA = topicsDto.FindAll(topic => topic.Score == TopicCycleEnum.TopicCycleEnumScore.A);
            listScoreA.Sort((x, y) => y.Media.CompareTo(x.Media));

            var listScoreBC = topicsDto.FindAll(topic => topic.Score != TopicCycleEnum.TopicCycleEnumScore.A);
            listScoreBC.Sort((x, y) => y.Media.CompareTo(x.Media));

            var topicsCycle = new List<TopicCycle>();

            TopicCycleEnum.Action lastActionBC =  TopicCycleEnum.Action.Law;
           
            if (listScoreBC.Count > 0){
                lastActionBC = listScoreBC.First().topic.GetLastAction();
            }

            foreach(TopicScoreInfoDTO topicA in listScoreA)
            {
                topicsCycle.Add(ConvertDtoToEntity(topicA, topicA.topic.GetLastAction()));
                
                if (listScoreBC.Count > 0){
                    topicsCycle.Add(ConvertDtoToEntity(listScoreBC.First(), lastActionBC));
                    lastActionBC = GetNextActionByScore(lastActionBC, listScoreBC.First().Score);
                }
            }

            if (topicsCycle.Count == 0){
                topicsCycle.Add(ConvertDtoToEntity(listScoreBC.First(), lastActionBC));
            }

            if (listScoreBC.Count >= 2){
                topicsCycle.Add(ConvertDtoToEntity(listScoreBC.ElementAt(1), listScoreBC.ElementAt(1).topic.GetLastAction()));
            }
            return topicsCycle;
        }

        private TopicCycle ConvertDtoToEntity(TopicScoreInfoDTO dto, TopicCycleEnum.Action lastAction) =>
            new TopicCycle{
                Score = dto.Score,
                Status = TopicCycleEnum.TopicCycleEnumStatus.Ready,
                Topic = dto.topic,
                Action = GetNextActionByScore(lastAction, dto.Score)
            };

        private async Task PersistTopicsCycle(List<TopicCycle> topicsCycle)
        {
            foreach(TopicCycle cycleItem in topicsCycle)
            {
                await _topicCycleRepository.AddTopicCycle(cycleItem);
            }
        }

        private TopicCycleEnum.Action GetNextActionByScore(
            TopicCycleEnum.Action lastAction, 
            TopicCycleEnum.TopicCycleEnumScore score
        )
        {
            if (score == TopicCycleEnum.TopicCycleEnumScore.A)
                return GetNextActionA(lastAction);
            if (score == TopicCycleEnum.TopicCycleEnumScore.B)
                return GetNextActionB(lastAction);
            return GetNextActionC(lastAction);
        }

        private TopicCycleEnum.Action GetNextActionA(TopicCycleEnum.Action lastAction)
        {
            switch(lastAction)
            {
                case TopicCycleEnum.Action.Exercises:
                case TopicCycleEnum.Action.ExercisesTwo:
                    return TopicCycleEnum.Action.Revision;
                case TopicCycleEnum.Action.Revision:
                    return TopicCycleEnum.Action.Law;
                case TopicCycleEnum.Action.Law:
                    return TopicCycleEnum.Action.Reading;
                case TopicCycleEnum.Action.Reading:
                    return TopicCycleEnum.Action.Exercises;
                default:
                    return TopicCycleEnum.Action.Reading;
            }
        }

        private TopicCycleEnum.Action GetNextActionB(TopicCycleEnum.Action lastAction)
        {
            switch(lastAction)
            {
                case TopicCycleEnum.Action.Exercises:
                    return TopicCycleEnum.Action.Revision;
                case TopicCycleEnum.Action.Revision:
                    return TopicCycleEnum.Action.ExercisesTwo;
                case TopicCycleEnum.Action.ExercisesTwo:
                    return TopicCycleEnum.Action.Reading;
                case TopicCycleEnum.Action.Reading:
                    return TopicCycleEnum.Action.Exercises;
                case TopicCycleEnum.Action.Law:
                default:
                    return TopicCycleEnum.Action.Reading;
            }
        }

        private TopicCycleEnum.Action GetNextActionC(TopicCycleEnum.Action lastAction)
        {
            switch(lastAction)
            {
                case TopicCycleEnum.Action.Exercises:
                case TopicCycleEnum.Action.ExercisesTwo:
                    return TopicCycleEnum.Action.Revision;
                case TopicCycleEnum.Action.Revision:
                    return TopicCycleEnum.Action.Reading;
                case TopicCycleEnum.Action.Reading:
                    return TopicCycleEnum.Action.Exercises;
                case TopicCycleEnum.Action.Law:
                default:
                    return TopicCycleEnum.Action.Reading;
            }
        }

       


    }
}