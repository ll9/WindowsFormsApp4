﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp4.Data;
using WindowsFormsApp4.Models;

namespace WindowsFormsApp4.Repositories
{
    public class ProjectTableRepository
    {
        private const string TableName = nameof(ApplicationDbContext.ProjectTables);
        private readonly AdoContext _context;

        public ProjectTableRepository(AdoContext context)
        {
            _context = context;
        }

        public IEnumerable<ProjectTable> List()
        {
            var projectTables = new List<ProjectTable>();
            var query = $@"
SELECT Id, Name, SyncStatus, IsDeleted, LastModified, ProjectId FROM {TableName}
";
            using (var reader = _context.ExecuteReader(query))
            {
                while (reader.Read())
                {
                    var projectTable = new ProjectTable(
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetBoolean(2),
                        reader.GetBoolean(3),
                        reader.GetDateTime(4),
                        reader.GetString(5));
                    projectTables.Add(projectTable);
                }
            }
            return projectTables;
        }

        public void Add(ProjectTable projectTable)
        {
            var query = $@"
INSERT INTO {TableName}(
Id, Name, SyncStatus, IsDeleted, LastModified, ProjectId
)
VALUES(
@Id, @Name, @SyncStatus, @IsDeleted, @LastModified, @ProjectId
)
";
            using (var connection = _context.GetConnection())
            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", projectTable.Id);
                command.Parameters.AddWithValue("@Name", projectTable.Name);
                command.Parameters.AddWithValue("@SyncStatus", projectTable.SyncStatus);
                command.Parameters.AddWithValue("@IsDeleted", projectTable.IsDeleted);
                command.Parameters.AddWithValue("@LastModified", projectTable.LastModified);
                command.Parameters.AddWithValue("@ProjectId", projectTable.ProjectId);

                command.ExecuteNonQuery();
            }

            CreateDefaultTableSchema(projectTable.Id);
        }

        public void CreateDefaultTableSchema(string projectTableId)
        {
            var query = $@"
INSERT INTO {nameof(ApplicationDbContext.TableSchemas)}
(
Id, ColumnName, IsActive, IsComboBox, ComboBoxValues, DisplayName, DisplayIndex, 
PhysicalColumnName, SyncStatus, IsDeleted, LastModified, ProjectTableId
)
VALUES(
@Id, @ColumnName, @IsActive, @IsComboBox, @ComboBoxValues, @DisplayName, @DisplayIndex, 
@PhysicalColumnName, @SyncStatus, @IsDeleted, @LastModified, @ProjectTableId
)
";
            using (var connection = _context.GetConnection())
            using (var command = new SQLiteCommand(query, connection))
                foreach (var name in DynamicEntity.GetPropertNames())
                {
                    command.Parameters.AddWithValue("@Id", Guid.NewGuid());
                    command.Parameters.AddWithValue("@ColumnName", name);
                    command.Parameters.AddWithValue("@IsActive", false);
                    command.Parameters.AddWithValue("@IsComboBox", false);
                    command.Parameters.AddWithValue("@ComboBoxValues", null);
                    command.Parameters.AddWithValue("@DisplayName", name);
                    command.Parameters.AddWithValue("@DisplayIndex", null);
                    command.Parameters.AddWithValue("@PhysicalColumnName", name);
                    command.Parameters.AddWithValue("@SyncStatus", false);
                    command.Parameters.AddWithValue("@IsDeleted", false);
                    command.Parameters.AddWithValue("@LastModified", null);
                    command.Parameters.AddWithValue("@ProjectTableId", projectTableId);

                    command.ExecuteNonQuery();
                }
        }
    }
}
