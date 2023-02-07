using AutoMapper;
using Microsoft.Extensions.Logging;
using MyApp.Data;
using MyApp.Data.Models;
using MyApp.Services.Models;
using System.Threading.Tasks;

namespace MyApp.Services
{
    public interface IUserService
    {
        Task<UserModel> Get(string username, string password);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<ProjectService> _logger;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository,
            ILogger<ProjectService> logger,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public Task<UserModel> Get(string username, string password)
        {
            var userDto = _userRepository.GetUser(username, password);
            var userModel = _mapper.Map<UserDto, UserModel>(userDto);
            return Task<UserModel>.FromResult(userModel);
        }
    }
}
