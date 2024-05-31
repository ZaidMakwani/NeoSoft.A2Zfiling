using MediatR;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;


namespace NeoSoft.A2Zfiling.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            

            return services;
        }
    }
}
