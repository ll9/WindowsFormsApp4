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

namespace WindowsFormsApp4.Controllers
{
    class MainController
    {
        private readonly MainView _view;
        private readonly ApplicationDbContext _efContext;
        private readonly AdoContext _adoContext;
        private readonly DbTableRepository _dbTableRepository;
        private readonly ProjectRepository _projectRepository;

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
            _efContext.SaveChanges();
            AddTable(addTableViewModel.Name);
        }

        private void AddTable(string tableName)
        {
            var table = _dbTableRepository.List(tableName);
            _view.AddGrid(table);
        }

        internal void UpdateChangesToDb(DataTable dataTable)
        {
            _dbTableRepository.Update(dataTable);
        }
    }
}
