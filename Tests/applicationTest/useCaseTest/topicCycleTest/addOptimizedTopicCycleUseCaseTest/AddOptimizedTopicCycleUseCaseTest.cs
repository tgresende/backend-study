using System.Collections.Generic;
using Apllication.useCases.topicCycle.addOptimizedTopicCycleUseCase;
using Domain.interfaces;
using Domain.entities;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.applicationTest.useCaseTest.topicCycleTest
{

    [TestClass]
    public class AddOptimizedTopicCycleUseCaseTest
    {

        private readonly AddOptimizedTopicCycleUseCase useCase;
        private readonly Mock<ITopicRepository> _topicRepository;
        private readonly Mock<ITopicCycleRepository> _topicCycleRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public AddOptimizedTopicCycleUseCaseTest()
        {
            _topicRepository= new Mock<ITopicRepository>();
            _topicCycleRepository= new Mock<ITopicCycleRepository>();
            _unitOfWork= new Mock<IUnitOfWork>();

            useCase = new AddOptimizedTopicCycleUseCase(
                _topicCycleRepository.Object,
                _topicRepository.Object,
                _unitOfWork.Object
            );
        }

        [TestMethod]
        public async void TestUseCaseCompleteTopics()
        {
            var subjectIdTest = 1;
            ConfigureCompleteEnvironment();
            await useCase.Execute(subjectIdTest);

            Assert.AreEqual("",result);
        }

        private void ConfigureCompleteEnvironment()
        {
            _topicRepository.Setup(x => x.GetTopics(It.IsAny<int>())).Returns();

        }


        private List<Topic> GetCompleteListTopics()
        {
            return new List<Topic>{
                new Topic {
                    Name = "topic 1",
                    Questions = new List<Question>{
                        new Question {
                            
                        }
                    }
                }
            }
        }
    }
}