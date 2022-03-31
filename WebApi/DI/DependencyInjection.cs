using Microsoft.Extensions.DependencyInjection;
using Infrasctructure.repositories;
using Domain.interfaces;
using Apllication.services.subject;
using Apllication.services.project;
using Apllication.useCases.subject.getSubjectUseCase;
using Apllication.useCases.subject.addSubjectUseCase;
using Apllication.useCases.subject.addSimpleSubjectCycleUseCase;
using Apllication.useCases.subject.getSubjectCycleUseCase;
using Apllication.useCases.topic.addTopicUseCase;
using Apllication.useCases.topic.getSubjectTopicsUseCase;
using Apllication.useCases.topicCycle.getTopicCycleUseCase;
using Apllication.useCases.topicCycle.addSimpleTopicCycleUseCase;


namespace WebApi.DI
{
    public class DependencyInjection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            RegisterRepostioriesDI(services);
            RegisterUseCasesDI(services);
            RegisterServicesDI(services);
        }

        private static void RegisterRepostioriesDI(IServiceCollection services)
        {
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISubjectCycleRepository, SubjectCycleRepository>();
            services.AddScoped<ITopicCycleRepository, TopicCycleRepository>();

        }

        private static void RegisterUseCasesDI(IServiceCollection services)
        {
            services.AddScoped<IGetSubjectUseCase, GetSubjectUseCase>();
            services.AddScoped<IAddSubjectUseCase, AddSubjectUseCase>();
            services.AddScoped<IAddTopicUseCase, AddTopicUseCase>();
            services.AddScoped<IGetSubjectTopicsUseCase, GetSubjectTopicsUseCase>();
            services.AddScoped<IGetSubjectTopicsUseCase, GetSubjectTopicsUseCase>();
            services.AddScoped<IAddSimpleSubjectCycleUseCase, AddSimpleSubjectCycleUseCase>();
            services.AddScoped<IGetSubjectCycleUseCase, GetSubjectCycleUseCase>();
            services.AddScoped<IGetTopicCycleUseCase, GetTopicCycleUseCase>();
            services.AddScoped<IAddSimpleTopicCycleUseCase, AddSimpleTopicCycleUseCase>();

        }

        private static void RegisterServicesDI(IServiceCollection services)
        {
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<IProjectService, ProjectService>();
        }

    }
}