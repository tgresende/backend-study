using Domain.entities;
namespace Apllication.useCases.subject.getSubjectCycleUseCase
{
    public class GetSubjectCycleUseCaseResponseModel
    {
        public int subjectCycleId { get; set; }
        public SubjectCycleEnum.SubjectCycleStatus status { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int StudyTimeMinutes { get; set; }
    }
}