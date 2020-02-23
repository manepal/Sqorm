using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sqorm.Models;

namespace Sqorm.Data.Client
{
    public interface IDatabaseConnection : IDisposable
    {
        /// <summary>
        /// Opens database connection.
        /// </summary>
        void Open();

        /// <summary>
        /// Closes database connection.
        /// </summary>
        void Close();

        /// <summary>
        /// Opens databse connection asynchronously.
        /// </summary>
        /// <returns></returns>
        Task OpenAsync();

        /// <summary>
        /// Executes provided sql query against database
        /// and returns the number of rows affected by the query.
        /// Ideal for performing Upsert operations.
        /// </summary>
        /// <param name="query">SQL upsert query to be fired against database.</param>
        /// <param name="queryParameters">Collection of query parameters</param>
        /// <returns>Number of rows affected by the query.</returns>
        int ExecuteNonQuery(string query, ParameterContainer queryParameters = null);

        /// <summary>
        /// Executes provided sql query against database and returns
        /// first row of first column type cast to the object of specifieed type 'T'
        /// </summary>
        /// <param name="query">SQL query to fetch sql data.</param>
        /// <param name="queryParameters">Collection of query parameters</param>
        /// <typeparam name="T">Desired object type for return value.</typeparam>
        /// <returns>First row of first column type cast to type 'T'.</returns>
        T ExecuteScalar<T>(string query, ParameterContainer queryParameters = null) where T : IEquatable<T>, IConvertible;
        
        /// <summary>
        /// Executes provided sql query against database and returns
        /// a collection of object of type 'T' mapped for query result data.
        /// </summary>
        /// <param name="query">SQL query to fetch sql data collection.</param>
        /// <param name="queryParameters">Collection of query parameters</param>
        /// <typeparam name="T">Desired object type for return value.</typeparam>
        /// <returns>Collection of objects of type 'T'</returns>
        IEnumerable<T> ExecuteReader<T>(string query, ParameterContainer queryParameters = null);

        /// <summary>
        /// Asynchronously executes provided sql query against database
        /// and returns the number of rows affected by the query.
        /// Ideal for performing Upsert operations.
        /// </summary>
        /// <param name="query">SQL upsert query to be fired against database.</param>
        /// <param name="queryParameters">Collection of query parameters</param>
        /// <returns>Number of rows affected by the query.</returns>
        Task<int> ExecuteNonQueryAsync(string query, ParameterContainer queryParameters = null);
        
        /// <summary>
        /// Asynchronously executes provided sql query against database and returns
        /// first row of first column type cast to the object of specified type 'T'
        /// </summary>
        /// <param name="query">SQL query to fetch sql data.</param>
        /// <param name="queryParameters">Collection of query parameters</param>
        /// <typeparam name="T">Desired object type for return value.</typeparam>
        /// <returns>First row of first column type cast to type 'T'.</returns>
        Task<T> ExecuteScalarAsync<T>(string query, ParameterContainer queryParameters = null) where T : IEquatable<T>, IConvertible;
        
        /// <summary>
        /// Asynchronously executes provided sql query against database returns
        /// a collection of objects of type 'T' mapped for query result data.
        /// </summary>
        /// <param name="query">SQL query to fetch sql data collection.</param>
        /// <param name="queryParameters">Collection of query parameters</param>
        /// <typeparam name="T">Desired object type for return value.</typeparam>
        /// <returns>Collection of objects of type 'T'</returns>
        Task<IEnumerable<T>> ExecuteReaderAsync<T>(string query, ParameterContainer queryParameters = null);
    }
}