using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp4.Data;
using WindowsFormsApp4.Models;
using WindowsFormsApp4.Repositories;
using System.ComponentModel;

namespace SyncTests.Repositories.Utils
{
    [TestFixture]
    class TableSchemaRepositoryTests
    {
        private AdoContext _context;
        private ApplicationDbContext _efContext;
        private TableSchemaRepository _tableSchemaRepository;
        private ProjectTableRepository _projectTableRepository;

        [SetUp]
        public void Setup()
        {
            ContextCreator.ResetDb();
            _context = ContextCreator.GetAdoContext();
            _efContext = ContextCreator.GetEfContext();
            _tableSchemaRepository = new TableSchemaRepository(_context, _efContext);
            _projectTableRepository = new ProjectTableRepository(_context);

            var someProjectTable = new ProjectTable("SomeName", null);
            _projectTableRepository.Add(someProjectTable);
        }

        [Test]
        public void List_WhenCalled_ReturnsResult()
        {
            var count = _tableSchemaRepository.List().Count();

            Assert.That(count, Is.GreaterThan(0));
        }
    }
}
