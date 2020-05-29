using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainDrivenDesign.Application.Interface;
using DomainDrivenDesign.Application.Service;
using DomainDrivenDesign.Domain.Interface;
using DomainDrivenDesign.Infrastructure.DbContexts;
using DomainDrivenDesign.Infrastructure.Repositorys;
using Microsoft.Extensions.DependencyInjection;

namespace DomainDrivenDesign.Web.Core.Extension
{
    public static class ServiceSetup
    {
        public static void RegisterService(this IServiceCollection services)
        {
            //注入App 应用层
            services.AddScoped<IStudentAppService, StudentAppService>();

            //注入Infrastucture 基础设施层
            services.AddScoped<IStudentRepository, StudentRepository>();

            //注入上下文
            services.AddScoped<StudyDbContext>();
        }
    }
}
