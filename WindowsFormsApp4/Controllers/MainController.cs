using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp4.Data;
using WindowsFormsApp4.Repositories;

namespace WindowsFormsApp4.Controllers
{
    class MainController
    {
        private readonly MainView _view;
        private readonly ApplicationDbContext _efContext;
        private readonly AdoContext _adoContext;
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
            _projectRepository = new ProjectRepository(_adoContext);

            Initialize();
        }

        private void Initialize()
        {
            _efContext.Database.Migrate();
            _projectRepository.CreateIfNotExists();
        }
    }
}
