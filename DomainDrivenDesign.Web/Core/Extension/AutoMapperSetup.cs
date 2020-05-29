using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DomainDrivenDesign.Application.AutoMappers;
using Microsoft.Extensions.DependencyInjection;

namespace DomainDrivenDesign.Web.Core.Extension
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection service)
        {
            //添加AutoMapper 服务
            service.AddAutoMapper(typeof(AutoMapperSetup));

            //注册配置
            AutoMapperConfig.Register();
        }
    }
}
