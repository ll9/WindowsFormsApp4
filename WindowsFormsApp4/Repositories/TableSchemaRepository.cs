using Microsoft.EntityFrameworkCore;
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
    public class TableSchemaRepository
    {
        private const string TableName = nameof(ApplicationDbContext.TableSchemas);
        private readonly AdoContext _context;
        private readonly ApplicationDbContext _efContext;

        public TableSchemaRepository(AdoContext context, ApplicationDbContext efContext)
        {
            _context = context;
            _efContext = efContext;
        }

        public ICollection<TableSchema> List()
        {
            return _efContext.TableSchemas.ToList();
        }

        public void Edit(TableSchema tableSchema)
        {
            bool isDetached = _efContext.Entry(tableSchema).State == EntityState.Detached;
            if (isDetached)
                _efContext.TableSchemas.Attach(tableSchema);

            _efContext.SaveChanges();
        }

        public void Remove(string id)
        {
            var tableSchema = _efContext.TableSchemas.SingleOrDefault(t => t.Id == id);

            if (tableSchema != null)
            {
                tableSchema.IsDeleted = true;
                tableSchema.SyncStatus = false;

                foreach (var entity in _efContext.DynamicEntities.Where(d => d.ProjectTableId == tableSchema.ProjectTableId))
                {
                    var property = typeof(DynamicEntity).GetProperties().Single(p => p.Name == tableSchema.ColumnName);
                    property.SetValue(entity, null);
                }
            }

            _efContext.SaveChanges();
        }
    }
}
