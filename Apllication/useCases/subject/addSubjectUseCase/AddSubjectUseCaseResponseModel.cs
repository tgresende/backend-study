namespace Apllication.useCases.subject.addSubjectUseCase
{
    public class AddSubjectUseCaseResponseModel
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public string Annotations { get; set; }
        public int ProjectId { get; set; }
    }
}