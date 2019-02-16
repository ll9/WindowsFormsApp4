using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp4.Data;
using WindowsFormsApp4.ViewModels;

namespace WindowsFormsApp4.Repositories
{
    class DbTableRepository
    {
        private readonly AdoContext _context;
        private string[] _defaultColumns = new[] {
            "Id TEXT DEFAULT (HEX(RANDOMBLOB(16))) PRIMARY KEY",
            "SyncStatus BOOLEAN",
            "IsDeleted BOOLEAN",
            "LastModified",
        };

        public DbTableRepository(AdoContext context)
        {
            _context = context;
        }

        public void Add(string tableName, IEnumerable<ColumnViewModel> columnViewModels)
        {
            var columnDefinitions = _defaultColumns
                .Concat(
                    columnViewModels
                    .Select(c => $"{c.Name} {c.SqlType}")
                )
                .Aggregate((current, next) => $"{current}, {next}");

            var query = $"CREATE TABLE {tableName}({columnDefinitions})";


            using (var connection = _context.GetConnection())
            using (var command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }


        public DataTable List(string tableName)
        {
            var query = $"SELECT * from {tableName}";

            using (var connection = _context.GetConnection())
            using (var adapter = new SQLiteDataAdapter(query, connection))
            {
                var table = new DataTable(tableName);
                adapter.Fill(table);
                return table;
            }
        }
    }
}
