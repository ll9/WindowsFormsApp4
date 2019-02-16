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
            _context = new ApplicationDbContext();
            var list = _context.BaseEntities.Local.ToBindingList();
            dataGridView1.DataSource = list;
            list.AddingNew += List_AddingNew;
            list.ListChanged += List_ListChanged;
        }

        private void List_ListChanged(object sender, ListChangedEventArgs e)
        {
            Console.WriteLine(e.ListChangedType);
        }

        private void List_AddingNew(object sender, AddingNewEventArgs e)
        {
            Console.WriteLine("Adding New");
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            _context.SaveChanges();
        }
    }
}
