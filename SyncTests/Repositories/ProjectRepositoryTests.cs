using NUnit.Framework;
using SyncTests.Repositories.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp4.Data;
using WindowsFormsApp4.Models;
using WindowsFormsApp4.Repositories;

namespace SyncTests.Repositories
{
    [TestFixture]
    class ProjectRepositoryTests
    {
        private AdoContext _context;
        private ProjectRepository _repo;

        [SetUp]
        public void Setup()
        {
            _context = ContextCreator.GetAdoContext();
            _repo = new ProjectRepository(_context);
        }

        [Test]
        public void ProjectExists_WhenNotExists_ReturnTrue()
        {
            var projectExists = _repo.ProjectExists();
            Assert.False(projectExists);
        }

        [Test]
        public void ProjectExists_WhenExists_ReturnTrue()
        {
            var project = new Project { Id = Guid.NewGuid().ToString(), Name = "SomeName" };

            _repo.Add(project);
            var projectExists = _repo.ProjectExists();

            Assert.True(projectExists);
        }
    }
}
