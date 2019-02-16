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
    class TableSchemaRepository
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
    }
}
