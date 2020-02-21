using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using Sqorm.Data.Mapping;

namespace Sqorm.Data.Client
{
    public abstract class DatabaseConnectionBase : IDatabaseConnection
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

        public T ExecuteScalar<T>(string query) where T : IEquatable<T>, IConvertible
        {
            using(var command  = GetDbCommand(query))
            {
                var queryResult = command.ExecuteScalar();
                return new TypeMapper<T>().MapScalar(queryResult);
            }
        }

        public IEnumerable<T> ExecuteReader<T>(string query)
        {
            using(var command = GetDbCommand(query))
            {
                var reader = command.ExecuteReader();
                return new TypeMapper<T>().MapDataReader(reader);
            }
        }

        public async Task<int> ExecuteNonQueryAsync(string query)
        {
            using(var command = GetDbCommand(query))
            {
                return await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<T> ExecuteScalarAsync<T>(string query) where T : IEquatable<T>, IConvertible
        {
            using(var command = GetDbCommand(query))
            {
                var queryResult = await command.ExecuteScalarAsync();
                return new TypeMapper<T>().MapScalar(queryResult);
            }
        }

        public async Task<IEnumerable<T>> ExecuteReaderAsync<T>(string query)
        {
            using(var command = GetDbCommand(query))
            {
                var reader = await command.ExecuteReaderAsync();
                return new TypeMapper<T>().MapDataReader(reader);
            }
        }

        private DbCommand GetDbCommand(string query)
        {
            DbCommand command = _connection.CreateCommand();
            command.CommandText = query;
            return command;
        }
    }
}