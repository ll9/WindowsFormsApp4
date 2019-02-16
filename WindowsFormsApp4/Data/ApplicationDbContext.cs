using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp4.Models;

namespace WindowsFormsApp4.Data
{
    public class ApplicationDbContext: DbContext
    {
        private readonly string _connectionString;

        public ApplicationDbContext(string connectionString = "Data Source=db.sqlite")
        {
            _connectionString = connectionString;
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTable> ProjectTables { get; set; }
        public DbSet<DynamicEntity> DynamicEntities { get; set; }
        public DbSet<TableSchema> TableSchemas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString);
        }
    }
}
