using AutoMapper;
using Microsoft.Extensions.Logging;
using MyApp.Data;
using MyApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Services
{
    public interface IProjectService
    {
        Task<ProjectModel> Do();
    }

    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ILogger<ProjectService> _logger;
        private readonly IMapper _mapper;

        public ProjectService(
            IProjectRepository projectRepository,
            ILogger<ProjectService> logger,
            IMapper mapper)
        {
            _projectRepository = projectRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ProjectModel> Do()
        {
            var name = await _projectRepository.Do();
            return new ProjectModel() { Name = name };
        }
    }
}
