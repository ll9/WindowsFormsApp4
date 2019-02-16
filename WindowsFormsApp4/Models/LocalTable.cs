using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4.Models
{
    /// <summary>
    /// Represents a list of the added projecttables
    /// </summary>
    public class LocalTable
    {
        public LocalTable()
        {

        }

        public LocalTable(string name)
        {
            Name = name;
            DisplayName = name;
        }

        public LocalTable(string name, string displayName)
        {
            Name = name;
            DisplayName = displayName;
        }

        [Key]
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}
