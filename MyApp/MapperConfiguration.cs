using System;
using System.Linq;
using AutoMapper;
using MyApp.Contracts;
using MyApp.Data.Models;
using MyApp.Services.Models;

namespace MyApp
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProjectModel, CreateProjectResponse>();
            CreateMap<UserDto, UserModel>();
        }
    }
}
