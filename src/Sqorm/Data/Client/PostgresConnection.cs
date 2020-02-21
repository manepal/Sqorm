using Npgsql;

namespace Sqorm.Data.Client
{
    public sealed class PostgresConnection : DatabaseConnectionBase
    {
        public PostgresConnection(string connectionString)
            : base(new NpgsqlConnection(connectionString))
        {}
    }
}