using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using HB.Infrastructure;
using HB.Domain.Repositories;
using AutoMapper.Extensions.ExpressionMapping;
using MediatR;
namespace HB.Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddAutoMapper(c =>  c.AddExpressionMapping(), Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddInfrastructureModule(configuration);
            services.AddInfrastructureModuleDb(configuration);
            return services;
        } public static IServiceCollection AddApplicationModuleTest(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddAutoMapper(c =>  c.AddExpressionMapping(), Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddInfrastructureModule(configuration);
            services.AddInfrastructureModuleDbTest(configuration);
            return services;
        }
    }
}
