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

        public void Add(TableSchema tableSchema)
        {
            var query = $@"
INSERT INTO {TableName}(
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
