using System.Collections.Generic;
namespace Domain.entities
{
    public class SubjectCycle
    {
        public int SubjectCycleId { get; set; }
        public int StudyTimeMinutes {get;set;}
        public SubjectCycleEnum.SubjectCycleStatus Status { get; set; }
        public Subject Subject {get;set;}

    }
}