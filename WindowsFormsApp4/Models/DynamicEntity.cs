using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4.Models
{
    class DynamicEntity
    {
        public DynamicEntity()
        {

        }

        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string StringCol1 { get; set; }
        public string StringCol2 { get; set; }
        public int? IntCol1 { get; set; }

        public bool SyncStatus { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public DateTime? LastModified { get; set; }

        [ForeignKey(nameof(ProjectTable))]
        public string ProjectTableId { get; set; }
    }
}
