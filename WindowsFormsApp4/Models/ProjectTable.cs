using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4.Models
{
    public class ProjectTable
    {
        public ProjectTable()
        {

        }

        public ProjectTable(string name, string projectId)
        {
            Name = name;
            ProjectId = projectId;
        }

        public ProjectTable(string id, string name, bool syncStatus, bool isDeleted, DateTime? lastModified, string projectId)
        {
            Id = id;
            Name = name;
            SyncStatus = syncStatus;
            IsDeleted = isDeleted;
            LastModified = lastModified;
            ProjectId = projectId;
        }

        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }

        public bool SyncStatus { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public DateTime? LastModified { get; set; }

        [ForeignKey(nameof(Project))]
        public string ProjectId { get; set; }
    }
}
