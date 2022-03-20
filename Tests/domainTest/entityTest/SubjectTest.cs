using Domain.entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.shared.entitiesTestFactory.subjects;

namespace Tests.domainTest.entityTest
{
    [TestClass]
    public class SubjectTest
    {

        private readonly SubjectTestFactory _subjectFactory;

        public SubjectTest()
        {
            _subjectFactory = new SubjectTestFactory();
        }

        [TestMethod]
        public void IsValidShouldReturnFalse_InvalidName()
        {
            var sub = _subjectFactory.GetCompleteSubject();
            
            sub.Name = "";

            Assert.IsFalse(sub.IsValid());

        }

        [TestMethod]
        public void IsValidShouldReturnFalse_InvalidWeight()
        {
            var sub = _subjectFactory.GetCompleteSubject();
            
            sub.Weight = 0;

            Assert.IsFalse(sub.IsValid());

            sub.Weight = -1;

            Assert.IsFalse(sub.IsValid());
        }

        [TestMethod]
        public void IsValidShouldReturnFalse_InvalidProject()
        {
            var sub = _subjectFactory.GetCompleteSubject();
            
            sub.Project = null;

            Assert.IsFalse(sub.IsValid());
        }

        [TestMethod]
        public void IsValidShouldReturnTrue_ValidEntity()
        {
            var sub = _subjectFactory.GetCompleteSubject();
            
            Assert.IsTrue(sub.IsValid());
        }

    }
}