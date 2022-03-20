using Apllication.services.subject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.shared.entitiesTestFactory.subjects;

namespace Tests.applicationTest.serviceTest.subjectTest
{

    [TestClass]
    public class SubjectServiceeTest
    {

        private readonly SubjectTestFactory _subjectFactory;

        public SubjectServiceeTest()
        {
            _subjectFactory = new SubjectTestFactory();
        }

        [TestMethod]
        public void GetInvalidSubjectPropertiesShouldReturnNothing()
        {
            var sub = _subjectFactory.GetCompleteSubject();

            var result = SubjectService.GetInvalidSubjectProperties(sub);

            Assert.AreEqual("",result);
        }

        [TestMethod]
        public void GetInvalidSubjectPropertiesShouldReturnInvalidNameMessage()
        {
            var sub = _subjectFactory.GetCompleteSubject();
            sub.Name = "";

            var result = SubjectService.GetInvalidSubjectProperties(sub);

            Assert.AreEqual($"Invalid Name: ''; ",result);
        }

        [TestMethod]
        public void GetInvalidSubjectPropertiesShouldReturnInvalidWeightMessage()
        {
            var sub = _subjectFactory.GetCompleteSubject();
            sub.Weight = 0;

            var result = SubjectService.GetInvalidSubjectProperties(sub);

            Assert.AreEqual($"Invalid Weight: '0'; ", result);
        }

        [TestMethod]
        public void GetInvalidSubjectPropertiesShouldReturnInvalidProjectMessage()
        {
            var sub = _subjectFactory.GetCompleteSubject();
            sub.Project = null;

            var result = SubjectService.GetInvalidSubjectProperties(sub);

            Assert.AreEqual($"Invalid Project: 'null'; ", result);
        }

    }
}