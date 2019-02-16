using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp4.Data;
using WindowsFormsApp4.Models;

namespace WindowsFormsApp4.Repositories
{
    class ProjectTableRepository
    {
        private const string TableName = nameof(ApplicationDbContext.ProjectTables);
        private readonly AdoContext _context;

        public ProjectTableRepository(AdoContext context)
        {
            _context = context;
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
        }

        public void CreateDefaultTableSchema()
        {
            var query = $@"
INSERT INTO {nameof(ApplicationDbContext.TableSchemas)}
(
Id, ColumnName, IsActive, IsComboBox, ComboBoxValues, DisplayName, Order, 
PhysicalColumnName, SyncStatus, IsDeleted, LastModified, ProjectTableId
)
VALUES(
@Id, @ColumnName, @IsActive, @IsComboBox, @ComboBoxValues, @DisplayName, @Order, 
@PhysicalColumnName, @SyncStatus, @IsDeleted, @LastModified, @ProjectTableId
)
";
            using (var connection = _context.GetConnection())
            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", tableSchema.Id);
                command.Parameters.AddWithValue("@ColumnName", tableSchema.ColumnName);
                command.Parameters.AddWithValue("@IsActive", tableSchema.IsActive);
                command.Parameters.AddWithValue("@IsComboBox", tableSchema.IsComboBox);
                command.Parameters.AddWithValue("@ComboBoxValues", tableSchema.ComboBoxValues);
                command.Parameters.AddWithValue("@DisplayName", tableSchema.DisplayName);
                command.Parameters.AddWithValue("@Order", tableSchema.Order);
                command.Parameters.AddWithValue("@PhysicalColumnName", tableSchema.PhysicalColumnName);
                command.Parameters.AddWithValue("@SyncStatus", tableSchema.SyncStatus);
                command.Parameters.AddWithValue("@IsDeleted", tableSchema.IsDeleted);
                command.Parameters.AddWithValue("@LastModified", tableSchema.LastModified);
                command.Parameters.AddWithValue("@ProjectTableId", tableSchema.ProjectTableId);

                command.ExecuteNonQuery();
            }
        }
    }
}
