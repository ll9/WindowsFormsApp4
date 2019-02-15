using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4.Models
{
    class BaseEntity
    {
        public BaseEntity(string property1, string property2)
        {
            Property1 = property1;
            Property2 = property2;
        }

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public bool SyncStatus { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public DateTime? LastModified { get; set; }

        public string Property1 { get; set; }
        public string Property2 { get; set; }
    }
}
