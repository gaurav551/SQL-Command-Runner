using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SQLandCommandRunner
{
    public class BackupDatabase
    {
        // public readonly ILogger<BackupDatabase> Logger;
        // public BackupDatabase(ILogger<BackupDatabase> logger)
        // {
        //     this.Logger = logger;

        // }
        private string connectionString = "server=DESKTOP-7EO032A\\SQLEXPRESS;Initial Catalog=pathshala;Trusted_Connection=True; MultipleActiveResultSets=True;";
        public Task BackUpDatabase()
        {
            try
            {
                var filePath = "D:\\Pathshalabackup" + DateTime.Now.ToString() + ".bak";
                //string query = "SELECT * from students";


                var query = $"BACKUP DATABASE Pathshala TO DISK='D:\\MyDatabase...bak'";

                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                var command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
                System.Console.WriteLine("BackUp Done");
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.ToString());
            }


            return Task.CompletedTask;
        }
        public bool RestoreDatabase(string fileName = "637378732892199703.bak")
        {
            string databaseName = "Pathshala";
            var filePath = $"C:\\Users\\Gaurav\\Desktop\\Pathshala\\PathshalaMain\\Pathshala\\wwwroot\\DatabaseBackups\\{fileName}";
            string commandText = $@"USE [master];
    ALTER DATABASE [{databaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    RESTORE DATABASE [{databaseName}] FROM DISK = N'{filePath}' WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 5;
    ALTER DATABASE [{databaseName}] SET MULTI_USER;";

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(commandText, connection);
                command.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.ToString());
                return false;

            }

        }
        public void DeleteData()
        {
            string[] tables = { "students", "teachers", "subjects" };
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            foreach (string s in ListTables())
            {
                string command = $"Delete from {s}";
                var SqlCommand = new SqlCommand(command, conn);
                SqlCommand.ExecuteNonQuery();
                System.Console.WriteLine(string.Format("Deleted from {0}", s));
            }

        }
        public IList<string> ListTables()
        {
            List<string> tables = new List<string>();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            DataTable dt = conn.GetSchema("Tables");
            foreach (DataRow row in dt.Rows)
            {
                string tablename = (string)row[2];
                tables.Add(tablename);
            }
            conn.Close();
            return tables;
        }
        //Get all backups in a folders with extention .Bak
        public void GetBackups()
        {
            DirectoryInfo d = new DirectoryInfo(@"C:\\Users\\Gaurav\\Desktop\\Pathshala\\PathshalaMain\\Pathshala\\wwwroot\\DatabaseBackups");// Dir with backups
            FileInfo[] Files = d.GetFiles("*.bak"); //Getting bak files
            //string str = "";
            foreach (FileInfo file in Files)
            {
                System.Console.WriteLine(file.Name);
            }




        }
    }
}