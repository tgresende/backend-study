using System.Collections.Generic;
using Domain.interfaces;
using Domain.entities;
using System.Threading.Tasks;

namespace Apllication.useCases.topic.getSubjectTopicsUseCase
{
    public class GetSubjectTopicsUseCase : IGetSubjectTopicsUseCase
    {
        private readonly ISubjectRepository _subjectRepository;

        public GetSubjectTopicsUseCase(ISubjectRepository subjectRepository)
        {
           _subjectRepository = subjectRepository;
        }
        public async Task<List<GetSubjectTopicsUseCaseResponseModel>> Execute(int subjectId) {
            var topics = await _subjectRepository.GetSubjectTopics(subjectId);
            return ConvertSubjectsListToResponseModel(topics);
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

        public GetSubjectTopicsUseCaseResponseModel ConvertTopicResponseModel(Topic topic) =>
            new GetSubjectTopicsUseCaseResponseModel{
                Annotations= topic.Annotations,
                Name = topic.Name,
                TopicId = topic.TopicId,
            };
        
    }
}