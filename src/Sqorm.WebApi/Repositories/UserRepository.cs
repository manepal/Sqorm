using Sqorm.Data.Client;
using Sqorm.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sqorm.WebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDatabaseConnection _connection;

        public UserRepository(IDatabaseConnection connection)
        {
            _connection = connection;
        }

        public async Task AddAsync(string username, string password)
        {
            string query = $"INSERT INTO users (username, password) VALUES('{username}', '{password}');";
            await _connection.OpenAsync();
            await _connection.ExecuteNonQueryAsync(query);
            _connection.Close();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            string query = "SELECT * FROM users;";
            await _connection.OpenAsync();
            var users = await _connection.ExecuteReaderAsync<User>(query);
            _connection.Close();

            return users;
        }
    }
}