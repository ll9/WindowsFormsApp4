using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp4.Data;
using WindowsFormsApp4.Models;
using WindowsFormsApp4.Repositories;
using WindowsFormsApp4.ViewModels;
using WindowsFormsApp4.Views;

namespace WindowsFormsApp4.Controllers
{
    public class MainController
    {
        private readonly MainView _view;
        private readonly ApplicationDbContext _efContext;
        private readonly AdoContext _adoContext;
        private readonly DbTableRepository _dbTableRepository;
        private readonly ProjectRepository _projectRepository;

        public SynchronisierenDialog SynchronisierenDialog { get; set; }

        public MainController(MainView view)
        {
            var builder = new SQLiteConnectionStringBuilder()
            {
                DataSource = "db.sqlite"
            };
            _view = view;
            _efContext = new ApplicationDbContext(builder.ConnectionString);
            _adoContext = new AdoContext(builder.ConnectionString);
            _dbTableRepository = new DbTableRepository(_adoContext);
            _projectRepository = new ProjectRepository(_adoContext);

            Initialize();
        }

        internal void Synchronize(ICollection<ProjectTable> dataSource)
        {
            dataSource
                .Where(t => t.SyncStatus == SyncStatus.NotRegistered)
                .ToList()
                .ForEach(t => t.SyncStatus = SyncStatus.NotSynchronized);
            _efContext.SaveChanges();

            // Step 1
            var project = _efContext.Projects.Single();
            // Step 2
            var tables = _efContext.ProjectTables.Where(t => t.SyncStatus == SyncStatus.NotSynchronized).ToList();
            // Step 3
            var tableSchemas = _efContext.TableSchemas
                .Where(t => t.SyncStatus == SyncStatus.NotSynchronized)
                .ToList();
            // Step 4
            //var dyn = _dbTableRepository.List()
        }

        internal void LoadSynchronizationTables()
        {
            if (SynchronisierenDialog != null && !SynchronisierenDialog.IsDisposed)
            {
                var tables = _efContext.ProjectTables
                    .Where(t => t.SyncStatus == SyncStatus.NotRegistered).ToList();

                SynchronisierenDialog.SetListBoxDataSource(tables);
            }
        }

        private void Initialize()
        {
            _efContext.Database.Migrate();
            _projectRepository.CreateIfNotExists();

            foreach (var localTable in _efContext.LocalTables.ToList())
            {
                AddTable(localTable.Name);
            }
        }

        internal void CreateTable(AddTableViewModel addTableViewModel)
        {
            var projectId = _projectRepository.GetLocalProjectId();

            _dbTableRepository.Add(addTableViewModel.Name, addTableViewModel.ColumnViewModels);
            _efContext.LocalTables.Add(new LocalTable(addTableViewModel.Name));
            _efContext.ProjectTables.Add(new ProjectTable(addTableViewModel.Name, _projectRepository.GetLocalProjectId()));

            _efContext.SaveChanges();
            AddTable(addTableViewModel.Name);
        }

        private void AddTable(string tableName)
        {
            var table = _dbTableRepository.List(tableName);
            // TODO: Activate in Production
            //table.DefaultView.RowFilter = "IsDeleted is null OR IsDeleted = false";
            table.RowDeleted += Table_RowDeleted;
            table.RowChanged += Table_RowChanged;
            _view.AddGrid(table);
        }

        private void Table_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            e.Row.Table.RowChanged -= Table_RowChanged;

            if (e.Row.Table.Columns.Contains("SyncStatus"))
            {
                e.Row.SetField("SyncStatus", false);
            }

            e.Row.Table.RowChanged += Table_RowChanged;
        }

        private void Table_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            e.Row.RejectChanges();
            if (e.Row.Table.Columns.Contains("IsDeleted"))
            {
                e.Row.SetField("IsDeleted", true);
            }
            if (e.Row.Table.Columns.Contains("SyncStatus"))
            {
                e.Row.SetField("SyncStatus", false);
            }
        }

        internal void UpdateChangesToDb(DataTable dataTable)
        {
            _dbTableRepository.Update(dataTable);
        }
    }
}
