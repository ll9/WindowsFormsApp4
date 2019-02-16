using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp4.Data;
using WindowsFormsApp4.Models;

namespace WindowsFormsApp4.Repositories
{
    public class ProjectRepository
    {
        private const string TableName = nameof(ApplicationDbContext.Projects);
        private readonly AdoContext _context;

        public ProjectRepository(AdoContext context)
        {
            _context = context;
        }

        public void Add(Project project)
        {
            var query = $@"
INSERT INTO {TableName}(Id, Name, SyncStatus, IsDeleted, LastModified)
VALUES(@Id, @Name, @SyncStatus, @IsDeleted, @LastModified)
";
            using (var connection = _context.GetConnection())
            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", project.Id);
                command.Parameters.AddWithValue("@Name", project.Name);
                command.Parameters.AddWithValue("@SyncStatus", project.SyncStatus);
                command.Parameters.AddWithValue("@IsDeleted", project.IsDeleted);
                command.Parameters.AddWithValue("@LastModified", project.LastModified);

                command.ExecuteNonQuery();
            }
        }

        public bool ProjectExists()
        {
            var query = $"SELECT COUNT(*) FROM {TableName}";
            var result = Convert.ToBoolean(_context.ExecuteScalar(query));
            return result;
        }

        public void CreateIfNotExists()
        {
            if (!ProjectExists())
            {
                var project = new Project
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = AppDomain.CurrentDomain.BaseDirectory
                };
                Add(project);
            }
        }
    }
}
