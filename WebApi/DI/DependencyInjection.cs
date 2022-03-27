using Microsoft.Extensions.DependencyInjection;
using Infrasctructure.repositories;
using Domain.interfaces;
using Apllication.useCases.subject.getSubjectUseCase;
using Apllication.useCases.subject.addSubjectUseCase;
using Apllication.useCases.topic.addTopicUseCase;


namespace WebApi.DI
{
    public class DependencyInjection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            RegisterRepostioriesDI(services);
            RegisterUseCasesDI(services);
        }

        private static void RegisterRepostioriesDI(IServiceCollection services)
        {
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void RegisterUseCasesDI(IServiceCollection services)
        {
            services.AddScoped<IGetSubjectUseCase, GetSubjectUseCase>();
            services.AddScoped<IAddSubjectUseCase, AddSubjectUseCase>();
            services.AddScoped<IAddTopicUseCase, AddTopicUseCase>();
        }

    }
}