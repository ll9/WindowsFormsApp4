using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4.Models
{
    class TableSchema
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string ColumnName { get; set; }
        public bool IsActive { get; set; }
        public bool IsComboBox { get; set; }
        public string ComboBoxValues { get; set; }

        public string DisplayName { get; set; }
        public int? Order { get; set; }
        public string PhysicalColumnName { get; set; }

        bool SyncStatus { get; set; } = true;
        bool IsDeleted { get; set; } = false;
        DateTime? LastModified { get; set; }

        [ForeignKey(nameof(ProjectTable))]
        public string ProjectTableId { get; set; }
    }
}
