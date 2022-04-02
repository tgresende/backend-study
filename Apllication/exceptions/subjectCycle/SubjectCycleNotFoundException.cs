using System;
using System.Threading.Tasks;
using Domain.interfaces;
using Domain.entities;


namespace Apllication.exceptions.subjectCycle
{
    public class SubjectCycleNotFoundException : Exception
    {
        public SubjectCycleNotFoundException() { }
        public SubjectCycleNotFoundException(string message) : base(message) { }
        public SubjectCycleNotFoundException(string message, Exception innerException) : base(message, innerException)
        { }

    }
}