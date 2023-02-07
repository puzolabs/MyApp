using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Services;
using System.Linq;
using System;
using MyApp.Contracts;
using MyApp.Data.Models;
using MyApp.Data;
using MyApp.Base.Exceptions;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using MyApp.Services.Models;
using System.Threading.Tasks;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public AuthController(
            IConfiguration config,
            ITokenService tokenService,
            IUserService userService,
            IMapper mapper)
        {
            _config = config;
            _tokenService = tokenService;
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IActionResult))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> Login(LoginUserRequest loginUserRequest)
        {
            var validUser = await _userService.Get(loginUserRequest.UserName, loginUserRequest.Password);

            if (validUser == null)
                return Unauthorized();

            string generatedToken = _tokenService.BuildToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), _config["Jwt:Audience"].ToString(), validUser);

            if (generatedToken == null)
                throw new Exception();

            return Ok(generatedToken);
        }
    }
}
