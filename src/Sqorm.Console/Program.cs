using System;
using Sqorm.Data.Attributes;
using Sqorm.Data.Client;

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
            TestSqlServer();
        }

        private static void TestSqlServer()
        {
            string sqlServerConnectionString = "server=localhost;database=SqormTestDb;Integrated Security=true";
            using (IDatabaseConnection connection = new SqlServerConnection(sqlServerConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM users;";
                var users = connection.ExecuteReader<User>(query);

                foreach (var user in users)
                {
                    System.Console.WriteLine(user.ToString());
                }
            }
        }
    }
}
