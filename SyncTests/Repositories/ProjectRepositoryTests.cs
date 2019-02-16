using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp4.Data;

namespace SyncTests.Repositories
{
    [TestFixture]
    class ProjectRepositoryTests
    {
        private AdoContext _context;

        [SetUp]
        public void Setup()
        {
            _context = new AdoContext("Data Source=:memorey:");
        }
    }
}
