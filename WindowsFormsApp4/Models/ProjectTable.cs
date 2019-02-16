using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4.Models
{
    class ProjectTable: SyncEntity
    {
        string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }

        public string ProjectId { get; set; }
    }
}
