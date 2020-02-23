using Sqorm.Data.Client;
using Sqorm.Models;
using Sqorm.WebApi.Models;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            string query = "SELECT * FROM users;";
            await _connection.OpenAsync();
            var users = await _connection.ExecuteReaderAsync<User>(query);
            _connection.Close();

            return users;
        }

        public async Task<User> GetByIdAsync(long id)
        {
            string query = "SELECT * FROM users WHERE id=@id;";
            var parameters = new ParameterContainer();
            parameters.Add("@id", id);
            
            await _connection.OpenAsync();
            var user = (await _connection.ExecuteReaderAsync<User>(query, parameters)).FirstOrDefault();
            _connection.Close();

            return user;
        }

        public async Task AddAsync(string username, string password)
        {
            string query = "INSERT INTO users (username, password) VALUES(@username, @password);";
            var parameters = new ParameterContainer();
            parameters.Add("@username", username);
            parameters.Add("@password", password);
            
            await _connection.OpenAsync();
            await _connection.ExecuteNonQueryAsync(query, parameters);
            _connection.Close();
        }
    }
}