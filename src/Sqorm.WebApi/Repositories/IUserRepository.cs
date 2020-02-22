using Sqorm.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sqorm.WebApi.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(string username, string password);
    }
}