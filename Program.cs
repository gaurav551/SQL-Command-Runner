using System;
using System.Data.OleDb;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using SQLandCommandRunner;

namespace COmmandRunner
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //SQLAccess.GetNames();
            var b = new BackupDatabase();
            b.BackUpDatabase();
           //b.DeleteData();
          // b.RestoreDatabase();
        //    foreach (var item in b.ListTables())
        //    {
        //        System.Console.WriteLine(item);
        //    }
        //   System.Console.WriteLine(string.Format("Total table is {0}",b.ListTables().Count));
             b.GetBackups();
      
           

        }
        
    }
}
