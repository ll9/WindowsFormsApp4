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
            ContextCreator.ResetDb();
            _context = ContextCreator.GetAdoContext();
            _repo = new ProjectTableRepository(_context);
        }

        [Test]
        public void Add_AddOne_AddsOne()
        {
            var projectTable = new ProjectTable("Test", null);

            _repo.Add(projectTable);

            var count = _repo.List().Count();
            Assert.That(count, Is.EqualTo(1));
        }

        [Test]
        public void Remove_HasOne_RemovesOne()
        {
            var projectTable = new ProjectTable("Test", null);

            _repo.Add(projectTable);
            _repo.Remove(projectTable.Id);

            var count = _repo.List().Count();
            Assert.That(count, Is.EqualTo(0));
        }
    }
}
