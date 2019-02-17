using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4.Models
{
    public enum SyncStatus
    {
        NotRegistered = 1,
        NotSynchronized = 2,
        Synchronized = 4
    }

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

        public ProjectTable(string id, string name, SyncStatus syncStatus, bool isDeleted, DateTime? lastModified, string projectId)
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

        public SyncStatus SyncStatus { get; set; } = SyncStatus.NotRegistered;
        public bool IsDeleted { get; set; } = false;
        public DateTime? LastModified { get; set; }

        [ForeignKey(nameof(Project))]
        public string ProjectId { get; set; }
    }
}
