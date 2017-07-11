using System;
using System.ComponentModel;
using Hangfire;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source=localhost;Initial Catalog=Hangfire.Sample;Integrated Security=True;";
            GlobalConfiguration.Configuration.UseSqlServerStorage(connectionString);

            using (new BackgroundJobServer())
            {
                while (true)
                {
                    var line = Console.ReadLine();
                    if (line.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    BackgroundJob.Enqueue(() => Console.WriteLine(line));
                }
            }
        }
    }
}
