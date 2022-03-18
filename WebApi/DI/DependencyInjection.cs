using System;
using System.Net.Mime;
using Microsoft.Extensions.DependencyInjection;
using Infrasctructure.repositories;
using Domain.interfaces;
using Apllication.useCases.subject.getSubjectUseCase;

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
        }

        private static void RegisterUseCasesDI(IServiceCollection services)
        {
            services.AddScoped<IGetSubjectUseCase, GetSubjectUseCase>();
        }

    }
}