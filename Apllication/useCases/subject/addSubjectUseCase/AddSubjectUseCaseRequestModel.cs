namespace Apllication.useCases.subject.addSubjectUseCase
{
    public class AddSubjectUseCaseRequestModel
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public string Annotations { get; set; }
        public int ProjectId { get; set; }
    }
}