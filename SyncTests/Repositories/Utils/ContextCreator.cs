using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp4.Data;

namespace SyncTests.Repositories.Utils
{
    class ContextCreator
    {
        // TODO: Use relative Paths
        private static readonly string dbPath = @"C:\Users\Lenovo G50-45\source\repos\WindowsFormsApp4\SyncTests\Db\db.sqlite";
        private static readonly string initialPath = @"C:\Users\Lenovo G50-45\source\repos\WindowsFormsApp4\SyncTests\Db\initial.sqlite";

        public static void ResetDb()
        {
            File.Delete(dbPath);
            File.Copy(initialPath, dbPath);
        }

        public static AdoContext GetAdoContext()
        {
            return new AdoContext($"Data Source={dbPath}");
        }

        public static ApplicationDbContext GetEfContext()
        {
            return new ApplicationDbContext($"Data Source={dbPath}");
        }
    }
}
