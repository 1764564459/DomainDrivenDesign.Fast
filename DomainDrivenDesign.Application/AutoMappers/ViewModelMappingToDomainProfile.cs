using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DomainDrivenDesign.Application.ViewModel;
using DomainDrivenDesign.Domain.Commands.Student;
using DomainDrivenDesign.Domain.Models;

namespace DomainDrivenDesign.Application.AutoMappers
{
    public class ViewModelMappingToDomainProfile:Profile
    {
        public ViewModelMappingToDomainProfile()
        {
            //手动配置实体值对象->视图模型映射
            CreateMap<StudentViewModel, Student>().ForPath(p => p.Address.Province, map => map.MapFrom(p => p.Province))
                .ForPath(p => p.Address.Street, map => map.MapFrom(p => p.Street))
                .ForPath(p => p.Address.City, map => map.MapFrom(p => p.City))
                .ForPath(p => p.Address.County, map => map.MapFrom(p => p.County)); //(p=>p.Id);

            //学生视图模型 -> 添加新学生命令模型
            CreateMap<StudentViewModel, RegisterStudentCommand>()
                .ConstructUsing(p => new RegisterStudentCommand(p.Name, p.Email, p.Phone, p.BirthDate));
        }
    }
}
