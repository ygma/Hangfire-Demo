using System;
using Hangfire;

namespace ConsumerDaemon
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source=localhost;Initial Catalog=Hangfire.Sample;Integrated Security=True;";
            GlobalConfiguration.Configuration.UseSqlServerStorage(connectionString);

            var options = new BackgroundJobServerOptions
            {
                WorkerCount = 1
            };

            using (new BackgroundJobServer(options))
            {
                Console.WriteLine("Hangfire Server started. Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
