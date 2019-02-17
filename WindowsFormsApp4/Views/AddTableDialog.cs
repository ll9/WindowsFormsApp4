using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp4.ViewModels;

namespace WindowsFormsApp4.Views
{
    public partial class AddTableDialog : Form
    {
        internal AddTableViewModel AddTableViewModel = new AddTableViewModel();

        public AddTableDialog()
        {
            InitializeComponent();

            var items = new[]
            {
                new { Text = "Text", Value = new SqlCsharpType("TEXT", typeof(string)) },
                new { Text = "Zahl", Value = new SqlCsharpType("DOUBLE", typeof(double?)) },
                new { Text = "Datum", Value = new SqlCsharpType("DATETIME", typeof(DateTime?)) },
            };
            SqlCombobox.DataSource = items;
            SqlCombobox.DisplayMember = "Text";
            SqlCombobox.ValueMember = "Value";

            addTableViewModelBindingSource.DataSource = AddTableViewModel;
        }

        private void columnViewModelsDataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[nameof(ColumnViewModel.SqlType)].Value = (SqlCombobox.DataSource as IEnumerable<dynamic>).First().Value;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
