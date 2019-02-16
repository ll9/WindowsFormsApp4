using NUnit.Framework;
using SyncTests.Repositories.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp4.Data;
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
    }
}
