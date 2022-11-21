using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyApp.Base.Exceptions;
using MyApp.Contracts;
using MyApp.Services;
using MyApp.Services.Models;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly ILogger<ProjectsController> _logger;
        private readonly IMapper _mapper;

        public ProjectsController(IProjectService projectService, ILogger<ProjectsController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _projectService = projectService;
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(CreateProjectResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorResponse))]
        public async Task<ActionResult<CreateProjectResponse>> Create([FromBody] CreateProjectRequest request)
        {
            _logger.LogInformation("create called");

            ProjectModel model = await _projectService.Create();
            CreateProjectResponse response = _mapper.Map<ProjectModel, CreateProjectResponse>(model);
            
            return Ok(response);
        }
    }
}
