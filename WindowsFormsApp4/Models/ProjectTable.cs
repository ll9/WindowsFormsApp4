using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4.Models
{
    class ProjectTable: SyncEntity
    {
        [Key]
        string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }

        [ForeignKey(nameof(Project))]
        public string ProjectId { get; set; }
    }
}
