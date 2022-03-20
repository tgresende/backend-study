using Domain.entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.domainTest.entityTest
{
    [TestClass]
    public class SubjectTest
    {
        [TestMethod]
        public void IsValidShouldReturnFalse_InvalidName()
        {
            var sub = CreateSubject();
            
            sub.Name = "";

            Assert.IsFalse(sub.IsValid());

        }

        [TestMethod]
        public void IsValidShouldReturnFalse_InvalidWeight()
        {
            var sub = CreateSubject();
            
            sub.Weight = 0;

            Assert.IsFalse(sub.IsValid());

            sub.Weight = -1;

            Assert.IsFalse(sub.IsValid());
        }

        [TestMethod]
        public void IsValidShouldReturnFalse_InvalidProject()
        {
            var sub = CreateSubject();
            
            sub.Project.ProjectId = 0;

            Assert.IsFalse(sub.IsValid());


            sub.Project.ProjectId = -1;

            Assert.IsFalse(sub.IsValid());

            sub = CreateSubject();

            sub.Project = null;

            Assert.IsFalse(sub.IsValid());
        }

        [TestMethod]
        public void IsValidShouldReturnTrue_ValidEntity()
        {
            var sub = CreateSubject();
            
            Assert.IsTrue(sub.IsValid());
        }

        private static Subject CreateSubject()
        {
            return new Subject(){
                SubjectId = 1,
                Name = "subject name",
                Weight = 1,
                Annotations = "subject annotatios",
                Project = new Project()
                {
                    ProjectId= 1,
                    Name = "project name"
                }
            };
        }
    }
}