using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyApp.Exceptions;
using MyApp.Services;

namespace MyApp.Auth
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _config;
        private readonly ITokenService _tokenService;
        private readonly ILogger<AuthMiddleware> _logger;

        public AuthMiddleware(RequestDelegate next, IConfiguration config, ITokenService tokenService, ILogger<AuthMiddleware> logger)
        {
            _next = next;
            _config = config;
            _tokenService = tokenService;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            string token = httpContext.Request.Headers.Authorization;

            if(token is not null)
            {
                token = token.ToString().Replace("Bearer ", string.Empty);
            }

            List<string> whiteList = new List<string>()
            {
                "/swagger",
                "/swagger/index.html",
                "/swagger/v1/swagger.json",
                "/auth/login"
            };

            if (!_tokenService.IsTokenValid(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), _config["Jwt:Audience"].ToString(), token))
            {
                if(!whiteList.Contains(httpContext.Request.Path.ToString().ToLower()))
                {
                    throw new UnauthorizedException("");
                }
            }

            await _next(httpContext);
        }
    }
}
