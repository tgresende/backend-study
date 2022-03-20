using System;
using System.Net.Mime;
using Microsoft.Extensions.DependencyInjection;
using Infrasctructure.repositories;
using Domain.interfaces;
using Apllication.useCases.subject.getSubjectUseCase;
using Apllication.useCases.subject.addSubjectUseCase;

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
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void RegisterUseCasesDI(IServiceCollection services)
        {
            services.AddScoped<IGetSubjectUseCase, GetSubjectUseCase>();
            services.AddScoped<IAddSubjectUseCase, AddSubjectUseCase>();

        }

    }
}