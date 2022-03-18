using System.Collections.Generic;
using Domain.interfaces;
using Domain.entities;
using System.Threading.Tasks;

namespace Apllication.useCases.subject.getSubjectUseCase
{
    public class GetSubjectUseCase : IGetSubjectUseCase
    {
        private readonly ISubjectRepository _subjectRepository;

        public GetSubjectUseCase(ISubjectRepository subjectRepository)
        {
           _subjectRepository = subjectRepository;
        }
        public async Task<List<GetSubjectUseCaseResponseModel>> Execute(int projectId) {
            var subjects = await _subjectRepository.GetSubjects(projectId);
            return ConvertSubjectsListToResponseModel(subjects);
        }

        public List<GetSubjectUseCaseResponseModel> ConvertSubjectsListToResponseModel(List<Subject> subjects)
        {
            var responseList = new List<GetSubjectUseCaseResponseModel>();    
            foreach(Subject sub in subjects)
            {
                responseList.Add(ConvertSubjectToResponseModel(sub));
            }
            return responseList;
        }

        public GetSubjectUseCaseResponseModel ConvertSubjectToResponseModel(Subject subject) =>
            new GetSubjectUseCaseResponseModel{
                Annotations= subject.Annotations,
                Name = subject.Name,
                SubjectId = subject.SubjectId,
                Weight = subject.Weight
            };
        
    }
}