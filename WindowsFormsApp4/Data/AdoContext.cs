using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4.Data
{
    class AdoContext
    {
        public SQLiteConnection GetConnection()
        {
            var builder = new SQLiteConnectionStringBuilder
            {
                DataSource = "db.sqlite",
            };
            var connection = new SQLiteConnection(builder.ConnectionString);
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
    }
}
