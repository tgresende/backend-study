using Domain.entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.shared.entitiesTestFactory.subjects;

namespace Tests.domainTest.entityTest
{
    [TestClass]
    public class TopicTest
    {

        private readonly TopicTestFactory _topicTestFactory;

        public TopicTest()
        {
            _topicTestFactory = new TopicTestFactory();
        }

        [TestMethod]
        public void IsValidShouldReturnFalse_InvalidName()
        {
            var topic = _topicTestFactory.GetCompleteTopic();
            
            topic.Name = "";

            Assert.IsFalse(topic.IsValid());
        }

        [TestMethod]
        public void IsValidShouldReturnFalse_InvalidProject()
        {
            var sub = _topicTestFactory.GetCompleteTopic();
            
            sub.Subject = null;

            Assert.IsFalse(sub.IsValid());
        }

        [TestMethod]
        public void IsValidShouldReturnTrue_ValidEntity()
        {
            var sub = _topicTestFactory.GetCompleteTopic();
            
            Assert.IsTrue(sub.IsValid());
        }

    }
}