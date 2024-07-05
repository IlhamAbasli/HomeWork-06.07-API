using AutoMapper;
using Domain.Entities;
using Service.DTOs.Groups;
using Service.DTOs.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Group, GroupDto>();
            CreateMap<GroupEditDto, Group>();
            CreateMap<GroupCreateDto, Group>();

            CreateMap<Student,StudentDto>().ForMember(dest => dest.Groups, opt => opt.MapFrom(src => src.Groups.Select(m => m.Name))); ;
            CreateMap<StudentEditDto, Student>();
            CreateMap<StudentCreateDto, Student>();
        }
    }
}
