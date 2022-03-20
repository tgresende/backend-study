using System.Threading.Tasks;
using Domain.entities;
namespace Apllication.useCases.subject.addSubjectUseCase
{
    public interface IAddSubjectUseCase
    {
        public Task<AddSubjectUseCaseResponseModel> Execute(AddSubjectUseCaseRequestModel requestModel) ;
    }
}