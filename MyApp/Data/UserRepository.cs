using System.Collections.Generic;
using System.Linq;
using MyApp.Contracts;
using MyApp.Data.Models;

namespace MyApp.Data
{
    public interface IUserRepository
    {
        UserDto GetUser(string username, string password);
    }

    public class UserRepository : IUserRepository
    {
        private readonly List<UserDto> users = new List<UserDto>();

        public UserRepository()
        {
            users.Add(new UserDto
            {
                UserName = "meir",
                Password = "1",
                Role = "team-leader"
            });
            users.Add(new UserDto
            {
                UserName = "ben",
                Password = "2",
                Role = "developer"
            });
            users.Add(new UserDto
            {
                UserName = "shimon",
                Password = "3",
                Role = "tester"
            });
        }

        public UserDto GetUser(string username, string password)
        {
            return users.Where(x => x.UserName.ToLower() == username.ToLower()
                && x.Password == password).FirstOrDefault();
        }
    }
}
