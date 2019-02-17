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
using WindowsFormsApp4.Models;

namespace WindowsFormsApp4.Views
{
    public partial class SynchronisierenDialog : Form
    {
        private readonly MainController _mainController;
        private ICollection<ProjectTable> _dataSource;

        public SynchronisierenDialog(MainController mainController)
        {
            InitializeComponent();
            _mainController = mainController;
            _mainController.SynchronisierenDialog = this;

            Initialize();
        }

        private void Initialize()
        {
            listBox1.DisplayMember = nameof(ProjectTable.Name);
            _mainController.LoadSynchronizationTables();
        }

        public void SetListBoxDataSource(ICollection<ProjectTable> source)
        {
            _dataSource = source;
            listBox1.DataSource = _dataSource;
        }

        private void SynchronizeButton_Click(object sender, EventArgs e)
        {
            _mainController.Synchronize(_dataSource);
        }
    }
}
