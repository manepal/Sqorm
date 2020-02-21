using System.Data.SqlClient;

namespace Sqorm.Data.Client
{
    public sealed class SqlServerConnection : DatabaseConnectionBase
    {
        public SqlServerConnection(string connectionString)
            : base (new SqlConnection(connectionString))
        {}
    }
}