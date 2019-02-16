using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp4.Data;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        private ApplicationDbContext _context;

        public Form1()
        {
            InitializeComponent();
        }
    }
}
