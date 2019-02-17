using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4.Models
{
    public class TableSchema
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string ColumnName { get; set; }
        public bool IsActive { get; set; }
        public bool IsComboBox { get; set; }
        public string ComboBoxValues { get; set; }

        public string DisplayName { get; set; }
        public int? DisplayIndex { get; set; }
        public string PhysicalColumnName { get; set; }

        public bool SyncStatus { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public DateTime? LastModified { get; set; }

        [ForeignKey(nameof(ProjectTable))]
        public string ProjectTableId { get; set; }

        public Type GetPropertyType()
        {
            var type = DynamicEntity.GetPropertyInfos().Single(p => p.Name.Equals(ColumnName)).PropertyType;
            return type;
        }
    }
}
