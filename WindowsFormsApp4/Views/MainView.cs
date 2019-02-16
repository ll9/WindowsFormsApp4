using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp4.Controllers;
using WindowsFormsApp4.Data;
using WindowsFormsApp4.Views;

namespace WindowsFormsApp4
{
    public partial class MainView : Form
    {
        private MainController _controller;

        public MainView()
        {
            InitializeComponent();
            _controller = new MainController(this);
        }

        private void AddTableButton_Click(object sender, EventArgs e)
        {
            var dialog = new AddTableDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _controller.AddTable(dialog.AddTableViewModel);
            }
        }

        internal void AddGrid(DataTable dataTable)
        {
            var tab = new TabPage(dataTable.TableName);
            var dataGrid = new DataGridView
            {
                Dock = DockStyle.Fill,
                DataSource = dataTable
            };
            //dataGrid.ColumnHeaderMouseClick += DataGrid_ColumnHeaderMouseClick;

            tab.Controls.Add(dataGrid);
            GridTabControl.TabPages.Add(tab);
        }
    }
}
