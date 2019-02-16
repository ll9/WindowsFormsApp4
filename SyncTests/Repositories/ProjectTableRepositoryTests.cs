using NUnit.Framework;
using SyncTests.Repositories.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp4.Data;
using WindowsFormsApp4.Models;
using WindowsFormsApp4.Repositories;

namespace SyncTests.Repositories
{
    [TestFixture]
    class ProjectTableRepositoryTests
    {
        private AdoContext _context;
        private ProjectTableRepository _repo;

        [SetUp]
        public void Setup()
        {
            _context = ContextCreator.GetAdoContext();
            _repo = new ProjectTableRepository(_context);
        }

        [Test]
        public void Add_AddOne_AddsOne()
        {
            var projectTable = new ProjectTable("Test", null);

            _repo.Add(projectTable);

            var count = _repo.List();
            Assert.That(count, Is.EqualTo(1));
        }
    }
}
