using System.Threading.Tasks;
using Domain.interfaces;
using Domain.entities;
using Domain.enums;


namespace Apllication.useCases.subjectCycle.finalizeSubjectCycleUseCase
{
    public class FinalizeSubjectCycleUseCase : IFinalizeSubjectCycleUseCase
    {
        private readonly ISubjectCycleRepository _subjectCycleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FinalizeSubjectCycleUseCase(
            ISubjectCycleRepository subjectCycleRepository,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _subjectCycleRepository = subjectCycleRepository;
        }

        public async Task Execute(int subjectCycleId)
        {
            var subjectCycle = await GetSubjectCycle(subjectCycleId);

            subjectCycle.Status = SubjectCycleEnum.SubjectCycleStatus.Done;

            await _unitOfWork.SaveChanges();
        }

        private async  Task<SubjectCycle> GetSubjectCycle(int subjectCycleId)
        {
            var subjectCycle = await _subjectCycleRepository.GetSubjectCycle(subjectCycleId);
            if (subjectCycle == null){
                throw new exceptions.subjectCycle.SubjectCycleNotFoundException($"Item de ciclo de assuntos id: {subjectCycleId} náo encontrado na base de dados");
            }
            return subjectCycle;
        }



    }
}