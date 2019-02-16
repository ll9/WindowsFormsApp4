using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4.Models
{
    public class Project
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }

        public bool SyncStatus { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public DateTime? LastModified { get; set; }
    }
}
