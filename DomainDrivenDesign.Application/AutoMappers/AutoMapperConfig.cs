using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDrivenDesign.Application.AutoMappers
{
    /// <summary>
    /// AutoMapper 配置
    /// </summary>
    public class AutoMapperConfig
    {
        /// <summary>
        /// 注册AutoMapper
        /// </summary>
        /// <returns></returns>
        public static MapperConfiguration Register()
        {
            return new MapperConfiguration(config =>
            {
                //领域模型->视图模型映射（读）
                config.AddProfile(new DomainToViewModelMappingProfile());

                //视图模型->领域模型映射（写）
                config.AddProfile(new ViewModelMappingToDomainProfile());
            });
        }
    }
}
