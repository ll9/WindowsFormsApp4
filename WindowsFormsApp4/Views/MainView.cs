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
            dataGrid.DefaultValuesNeeded += DataGrid_DefaultValuesNeeded;
            //dataGrid.ColumnHeaderMouseClick += DataGrid_ColumnHeaderMouseClick;

            tab.Controls.Add(dataGrid);
            GridTabControl.TabPages.Add(tab);
        }

        private void DataGrid_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            var hasIdColumn = e.Row.DataGridView.Columns.Contains("Id");
            if (hasIdColumn)
            {
                if (e.Row.DataGridView.Columns["Id"].ValueType == typeof(string))
                {
                    e.Row.Cells["Id"].Value = Guid.NewGuid().ToString();
                }
            }
        }

        private void SaveAllButton_Click(object sender, EventArgs e)
        {
            foreach (var control in GridTabControl.Controls)
            {
                if (control is TabPage tabPage)
                {
                    if (tabPage.Controls[0] is DataGridView dataGridView)
                    {
                        if (dataGridView.DataSource is DataTable dataTable)
                        {
                            _controller.UpdateChangesToDb(dataTable);
                        }
                    }
                }
            }
        }
    }
}
