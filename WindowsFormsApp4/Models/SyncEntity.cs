using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4.Models
{
    abstract class SyncEntity
    {
        bool SyncStatus { get; set; } = true;
        bool IsDeleted { get; set; } = false;
        DateTime? LastModified { get; set; }
    }
}
