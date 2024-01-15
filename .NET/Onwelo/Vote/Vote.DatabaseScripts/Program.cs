
using System.Configuration;
using System.Diagnostics;
using System.Reflection;

namespace Vote.DatabaseScripts
{
    class Program
    {
        static readonly string DatabaseName = GetDatabaseName();
        static readonly string DbServer = GetDatabaseServer();

        static void Main()
        {
            Console.Title = "AliaSQL Database Migrations Visual Studio Runner";


            var currentDirectory = Directory.GetCurrentDirectory();

            
            var scriptspath = Path.Combine(currentDirectory,"Scripts");
            var userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var deployerpath = Path.Combine(userProfile, ".nuget\\packages\\aliasql\\2.0.0\\tools", "AliaSQL.exe");
            var p = new Process();
            var keySelection = string.Empty;

            while (string.Compare(keySelection, "Exit", StringComparison.InvariantCultureIgnoreCase) != 0)
            {
                if (!string.IsNullOrEmpty(keySelection))
                {
                    Console.WriteLine();
                    var cmdArguments = string.Format("{0} {1} {2} \"{3}", keySelection, DbServer, DatabaseName, scriptspath);
                    p.StartInfo.FileName = deployerpath;
                    p.StartInfo.Arguments = cmdArguments;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.Start();

                    Console.WriteLine(p.StandardOutput.ReadToEnd());
                    Console.WriteLine("Press Any Key to Continue");
                }
                else
                {
                    DrawMenu();
                }

                var key = Console.ReadKey(true);
                keySelection = GetVerbForKeySelection(key);
            }
        }

        private static void DrawMenu()
        {
            Console.Clear();

            Console.WriteLine(" Database: " + DatabaseName);
            Console.WriteLine(" Server: " + DbServer);
            Console.WriteLine(" ----------------------------------------------------------------------------");
            Console.WriteLine(" 1. Create");
            Console.WriteLine(" 2. Exit program");
        }

        /// <summary>
        ///returns project name and removes the word ".database."
        /// </summary>
        /// <returns></returns>
        private static string GetDatabaseName()
        {
            var databasename = ConfigurationManager.AppSettings["DatabaseName"];

            if (string.IsNullOrEmpty(databasename))
            {
                var projectname = Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly()?.Location);

                databasename = projectname.Replace("Database.", "").Replace(".Database", "").Replace("Database", "");
            }
            return databasename;
        }

        private static string GetDatabaseServer()
        {
            var servername = ConfigurationManager.AppSettings["DatabaseServer"];

            if (string.IsNullOrEmpty(servername))
            {
                servername = ".\\sqlexpress";
            }
            return servername;
        }

        private static string GetVerbForKeySelection(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    return "Create";               
                case ConsoleKey.NumPad2:
                    return "Exit";
                default:
                    return string.Empty;
            }
        }
    }
}
