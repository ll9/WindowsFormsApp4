using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4.Models
{
    class Project: SyncEntity
    {
        string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
    }
}
