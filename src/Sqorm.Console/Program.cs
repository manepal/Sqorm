using System;
using Sqorm.Data.Attributes;
using Sqorm.Data.Client;
using Sqorm.Models;
using Console = System.Console;

namespace Sqorm.Console
{
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        [SqormDataField("is_deleted")]
        public bool IsDeleted { get; set; }
        
        [SqormDataField("date_created")]
        public DateTime CreatedAt { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} Username: {Username} Password: {Password} IsDeleted: {IsDeleted} CreatedAt: {CreatedAt}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("From Sql Server...");
            TestSqlServer();
            System.Console.WriteLine("From Postgres server...");
            TestPostgres();
        }

        private static void TestSqlServer()
        {
            TestDbConnection(new SqlServerConnection("server=localhost;database=SqormTestDb;Integrated Security=true"));
        }

        private static void TestPostgres()
        {
            TestDbConnection(new PostgresConnection("Server=localhost;Port=5432;Database=SqormTestDb;User Id=postgres;Password=postgrespass;"));
        }

        private static void TestDbConnection(IDatabaseConnection connection)
        {
            connection.Open();
            connection.SetCommandType(SqormCommandType.Text);
            string query = "SELECT * FROM users WHERE id >= @id;";
            var users = connection.ExecuteReader<User>(query, new ParameterContainer {{ "@id", 1 }});
            query = "SELECT * FROM users WHERE id=@id;";
            connection.SetCommandType(SqormCommandType.StoredProcedure);
            connection.Close();

            foreach (var user in users)
            {
                System.Console.WriteLine(user.ToString());
            }
        }
    }
}
