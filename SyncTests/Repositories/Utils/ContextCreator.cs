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
        public static AdoContext GetAdoContext()
        {
            // TODO: Use relative Paths
            var dbPath = @"C:\Users\Lenovo G50-45\source\repos\WindowsFormsApp4\SyncTests\Db\db.sqlite";
            var initialPath = @"C:\Users\Lenovo G50-45\source\repos\WindowsFormsApp4\SyncTests\Db\initial.sqlite";

            File.Delete(dbPath);
            File.Copy(initialPath, dbPath);

            return new AdoContext($"Data Source={dbPath}");
        }
    }
}
