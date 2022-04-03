using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.interfaces;
using Domain.entities;
using Domain.enums;

namespace Apllication.useCases.topicCycle.getTopicCycleUseCase
{
    public class GetTopicCycleUseCase : IGetTopicCycleUseCase
    {
        private readonly ITopicCycleRepository _topicCycleRepository;
        public GetTopicCycleUseCase(ITopicCycleRepository topicCycleRepository)
        {
            _topicCycleRepository = topicCycleRepository;
        }

        public async Task<List<GetTopicCycleUseCaseResponseModel>> Execute(int projectId)
        {
            var topicsCycle = await _topicCycleRepository.GetTopicCycleBySubjectAndStatus(projectId, TopicCycleEnum.TopicCycleEnumStatus.Ready);

            return ParseListToResponseModel(topicsCycle);
        }

        private List<GetTopicCycleUseCaseResponseModel> ParseListToResponseModel(List<TopicCycle> topicsCycle)
        {
            List<GetTopicCycleUseCaseResponseModel> result = new();
            foreach(TopicCycle cycleItem in topicsCycle)
            {
                result.Add(ParseEntityToResponseModel(cycleItem));
            }
            return result;
        }

        private GetTopicCycleUseCaseResponseModel ParseEntityToResponseModel(TopicCycle topicCycle) =>
        new GetTopicCycleUseCaseResponseModel{
            Score = topicCycle.Score,
            topicCycleId = topicCycle.TopicCycleId,
            TopicName = topicCycle.Topic.Name,
            topicId = topicCycle.Topic.TopicId,
            Action = topicCycle.Action
        };

    }
}