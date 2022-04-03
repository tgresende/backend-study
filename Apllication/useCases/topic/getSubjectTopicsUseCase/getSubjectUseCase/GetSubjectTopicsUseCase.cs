using System.Collections.Generic;
using Domain.interfaces;
using Domain.entities;
using System.Threading.Tasks;

namespace Apllication.useCases.topic.getSubjectTopicsUseCase
{
    public class GetSubjectTopicsUseCase : IGetSubjectTopicsUseCase
    {
        private readonly ITopicRepository _topicRepository;

        public GetSubjectTopicsUseCase(ITopicRepository topicRepository)
        {
           _topicRepository = topicRepository;
        }
        public async Task<List<GetSubjectTopicsUseCaseResponseModel>> Execute(int subjectId) {
            var topics = await _topicRepository.GetTopicsWithQuestions(subjectId);
            
            var topicDTO = ConvertSubjectsListToResponseModel(topics);

            topicDTO.Sort((x, y) => y.Media.CompareTo(x.Media));

            return topicDTO;
        }

        public List<GetSubjectTopicsUseCaseResponseModel> ConvertSubjectsListToResponseModel(List<Topic> topics)
        {
            var responseList = new List<GetSubjectTopicsUseCaseResponseModel>();    
            foreach(Topic topic in topics)
            {
                responseList.Add(ConvertTopicResponseModel(topic));
            }
            return responseList;
        }

        public GetSubjectTopicsUseCaseResponseModel ConvertTopicResponseModel(Topic topic){
            int daysOldToCalcScore = 15;
            
            var scoreDto = topic.CalcScore(daysOldToCalcScore);
            
            return new GetSubjectTopicsUseCaseResponseModel{
                Annotations= topic.Annotations,
                Name = topic.Name,
                TopicId = topic.TopicId,
                Media = scoreDto.Media,
                Score = scoreDto.Score
            };

        }
            
        
    }
}