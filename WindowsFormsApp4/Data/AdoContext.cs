using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4.Data
{
    public class AdoContext
    {
        private string _connectionString;

        public AdoContext(string connectionString = null)
        {
            var builder = new SQLiteConnectionStringBuilder
            {
                DataSource = "db.sqlite",
            };
            _connectionString = connectionString ?? builder.ConnectionString;
        }

        public SQLiteConnection GetConnection()
        {
            
            var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            return connection;
        }

        public void ExecuteQuery(string query)
        {
            using (var connection = GetConnection())
            using (var command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public object ExecuteScalar(string query)
        {
            using (var connection = GetConnection())
            using (var command = new SQLiteCommand(query, connection))
            {
                return command.ExecuteScalar();
            }
        }

        public SQLiteDataReader ExecuteReader(string query)
        {
            using (var connection = GetConnection())
            using (var command = new SQLiteCommand(query, connection))
            {
                return reader = command.ExecuteReader();
            }
        }
    }
}
