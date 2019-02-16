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

        public ApplicationDbContext()
        {
            _connectionString = "Data Source=db.sqlite";
        }

        public ApplicationDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTable> ProjectTables { get; set; }
        public DbSet<DynamicEntity> DynamicEntities { get; set; }
        public DbSet<TableSchema> TableSchemas { get; set; }
        public DbSet<LocalTable> LocalTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().Property(p => p.Id).HasDefaultValueSql("HEX(RANDOMBLOB(16))");
            modelBuilder.Entity<ProjectTable>().Property(p => p.Id).HasDefaultValueSql("HEX(RANDOMBLOB(16))");
            modelBuilder.Entity<DynamicEntity>().Property(p => p.Id).HasDefaultValueSql("HEX(RANDOMBLOB(16))");
            modelBuilder.Entity<TableSchema>().Property(p => p.Id).HasDefaultValueSql("HEX(RANDOMBLOB(16))");
        }
    }
}
