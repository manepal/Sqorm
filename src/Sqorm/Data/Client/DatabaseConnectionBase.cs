using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace Sqorm.Data.Client
{
    public class DatabaseConnectionBase : IDatabaseConnection
    {
        protected readonly DbConnection _connection;

        public DatabaseConnectionBase(DbConnection connection)
        {
            _connection = connection;
        }

        public void Open()
        {
            _connection.Open();
        }

        public async Task OpenAsync()
        {
            await _connection.OpenAsync();
        }

        public void Close()
        {
            _connection.Close();
        }

        public void Dispose()
        {
            _connection.Dispose();
        }

        public int ExecuteNonQuery(string query)
        {
            using(var command = GetDbCommand(query))
            {
                return command.ExecuteNonQuery();
            }
        }

        public T ExecuteScalar<T>(string query)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> ExecuteReader<T>(string query)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> ExecuteNonQueryAsync(string query)
        {
            using(var command = GetDbCommand(query))
            {
                return await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<T> ExecuteScalarAsync<T>(string query)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<T>> ExecuteReaderAsync<T>(string query)
        {
            throw new System.NotImplementedException();
        }

        private DbCommand GetDbCommand(string query)
        {
            DbCommand command = _connection.CreateCommand();
            command.CommandText = query;
            return command;
        }
    }
}