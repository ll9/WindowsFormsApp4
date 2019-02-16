using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4.Models
{
    class TableSchema: SyncEntity
    {
        string Id { get; set; } = Guid.NewGuid().ToString();
        public string ColumnName { get; set; }
        public bool IsActive { get; set; }
        public bool IsComboBox { get; set; }
        public string ComboBoxValues { get; set; }

        public string DisplayName { get; set; }
        public int? Order { get; set; }
        public string PhysicalColumnName { get; set; }

        public string ProjectTableId { get; set; }
    }
}
