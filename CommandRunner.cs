using System;
using System.Data.SqlClient;
using COmmandRunner;
using Microsoft.Extensions.Logging;

namespace SQLandCommandRunner
{
    public class CommandRunner
    {
        public readonly ILogger<CommandRunner> Log ;
        public CommandRunner(ILogger<CommandRunner> log)
        {
            this.Log = log;

        }
        public void RunCommand()
        {

            var ss = new SQL();
            var a = ss.GetStudentNames();
            int i = 1;
            foreach (var x in a)
            {
                System.Console.WriteLine($" SN {i} {x}");
                i++;
            }
            if (IsTrue())
            {
                //Run powershell command
                string commandToRun = "python --version";
                System.Diagnostics.Process si = new System.Diagnostics.Process();
                si.StartInfo.WorkingDirectory = "c:\\";
                si.StartInfo.UseShellExecute = false;
                si.StartInfo.FileName = "cmd.exe";
                si.StartInfo.Arguments = "/c" + " " + commandToRun;
                si.StartInfo.CreateNoWindow = true;
                si.StartInfo.RedirectStandardInput = true;
                si.StartInfo.RedirectStandardOutput = true;
                si.StartInfo.RedirectStandardError = true;
                si.Start();
                string output = si.StandardOutput.ReadToEnd();
                si.Close();
                System.Console.WriteLine(output);
            }


        }
        //Check if database is connected.
        public static bool IsTrue()
        {

            string connetionString = null;

            connetionString = "server=DESKTOP-7EO032A\\SQLEXPRESS;Initial Catalog=pathshala;Trusted_Connection=True; MultipleActiveResultSets=True;";

            var cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                System.Console.WriteLine("Connected");
                cnn.Close();
                return true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
