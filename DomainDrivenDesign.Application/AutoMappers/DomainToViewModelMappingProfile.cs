using System;
using System.Collections.Generic;
using System.Text;
using DomainDrivenDesign.Application.ViewModel;
using DomainDrivenDesign.Domain.Models;
using AutoMapper;

namespace DomainDrivenDesign.Application.AutoMappers
{
    public class DomainToViewModelMappingProfile:Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Student, StudentViewModel>()
                .ForMember(p => p.Province, map => map.MapFrom(p => p.Address.Province))
                .ForMember(p => p.City, map => map.MapFrom(p => p.Address.City))
                .ForMember(p => p.County, map => map.MapFrom(p => p.Address.County))
                .ForMember(p => p.Street, map => map.MapFrom(p => p.Address.Street));
        }
    }
}
