using System;
using System.Threading.Tasks;
using Domain.interfaces;
using Domain.entities;


namespace Apllication.exceptions.subject
{
    public class SubjectsProjectNotFoundException : Exception
    {
        public SubjectsProjectNotFoundException() { }
        public SubjectsProjectNotFoundException(string message) : base(message) { }
        public SubjectsProjectNotFoundException(string message, Exception innerException) : base(message, innerException)
        { }

    }
}