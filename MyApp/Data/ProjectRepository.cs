using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Data
{
    public interface IProjectRepository
    {
        Task<Guid> Create(string name);
    }

    public class ProjectRepository : IProjectRepository
    {
        private const string TABLE_NAME = "projects";
        private readonly IDatabase _database;

        public ProjectRepository(IDatabase database)
        {
            _database = database;
        }

        public async Task<Guid> Create(string name)
        {
            Guid guid = Guid.NewGuid();

            var sql =
                $"INSERT INTO {TABLE_NAME} (id, name) " +
                $"VALUES ('{guid}', '{name}')";

            await _database.Do(sql);

            return guid;
        }
    }
}
