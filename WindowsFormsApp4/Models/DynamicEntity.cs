using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4.Models
{
    public class DynamicEntity
    {
        public DynamicEntity()
        {

        }

        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string StringCol1 { get; set; }
        public string StringCol2 { get; set; }
        public int? IntCol1 { get; set; }

        public SyncStatus SyncStatus { get; set; } = SyncStatus.NotSynchronized;
        public bool IsDeleted { get; set; } = false;
        public DateTime? LastModified { get; set; }

        [ForeignKey(nameof(ProjectTable))]
        public string ProjectTableId { get; set; }

        public static IEnumerable<PropertyInfo> GetPropertyInfos()
        {
            var propertyInfos = typeof(DynamicEntity).GetProperties()
                .Where(p => (
                    p.Name != nameof(Id) &&
                    p.Name != nameof(SyncStatus) &&
                    p.Name != nameof(IsDeleted) &&
                    p.Name != nameof(LastModified) &&
                    p.Name != nameof(ProjectTableId)
                ));

            return propertyInfos;
        }

        public static IEnumerable<string> GetPropertyNames()
        {
            var propertyList = GetPropertyInfos()
                .Select(p => p.Name);

            return propertyList;
        }
    }
}
