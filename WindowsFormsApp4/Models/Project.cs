using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4.Models
{
    class Project
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }

        bool SyncStatus { get; set; } = true;
        bool IsDeleted { get; set; } = false;
        DateTime? LastModified { get; set; }
    }
}
