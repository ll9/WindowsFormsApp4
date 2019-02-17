using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp4.Data;
using WindowsFormsApp4.Models;

namespace WindowsFormsApp4.Repositories
{
    public class DynamicEntityRepository
    {
        private const string TableName = nameof(ApplicationDbContext.DynamicEntities);
        private readonly AdoContext _context;
        private readonly ApplicationDbContext _efContext;

        public DynamicEntityRepository(AdoContext context, ApplicationDbContext efContext)
        {
            _context = context;
            _efContext = efContext;
        }

        public void Add(DynamicEntity dynamicEntity)
        {
            dynamicEntity.SyncStatus = SyncStatus.NotSynchronized;
            _efContext.DynamicEntities.Add(dynamicEntity);

            _efContext.SaveChanges();
        }

        public void Edit(DynamicEntity dynamicEntity)
        {
            bool isDetached = _efContext.Entry(dynamicEntity).State == EntityState.Detached;
            if (isDetached)
                _efContext.DynamicEntities.Attach(dynamicEntity);

            _efContext.SaveChanges();
        }

        public void Remove(string id)
        {
            var dynamicEntity = _efContext.DynamicEntities.SingleOrDefault(t => t.Id == id);

            if (dynamicEntity != null)
            {
                dynamicEntity.IsDeleted = true;
                dynamicEntity.SyncStatus = SyncStatus.NotSynchronized;
            }

            _efContext.SaveChanges();
        }
    }
}
