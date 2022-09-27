using System.Configuration;

namespace Cafe.Persistence
{
    public class DatabaseConnection
    {
        public static DatabaseConnection Instance { get => _instance; }
        private static DatabaseConnection _instance;
        private string? _connectionString;
        private DatabaseConnection()
        {
            _connectionString = ConfigurationManager.AppSettings["cafedb"];
        }

        static DatabaseConnection()
        {
            _instance = new DatabaseConnection();
        }

        public string? GetConnectionString() => _connectionString;
    }
}
