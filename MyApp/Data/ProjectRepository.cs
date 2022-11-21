using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Data
{
    public interface IProjectRepository
    {
        Task<string> Create();
    }

    public class ProjectRepository : IProjectRepository
    {
        private readonly IDatabase _database;

        public ProjectRepository(IDatabase database)
        {
            _database = database;
        }

        public async Task<string> Create()
        {
            return await Task.FromResult("meir");
        }
    }
}
