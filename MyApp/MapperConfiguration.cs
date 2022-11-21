using System;
using System.Linq;
using AutoMapper;
using MyApp.Contracts;
using MyApp.Services.Models;

namespace MyApp
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProjectModel, CreateProjectResponse>();
        }
    }
}
