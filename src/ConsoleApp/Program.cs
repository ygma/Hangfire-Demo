using System.ComponentModel;
using Hangfire;
using Microsoft.Owin.Hosting;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source=localhost;Initial Catalog=Hangfire.Sample;Integrated Security=True;";
            GlobalConfiguration.Configuration.UseSqlServerStorage(connectionString);

            var url = "http://localhost:9000";

            using (WebApp.Start<Startup>(url))
            using (new BackgroundJobServer())
            {
                IBackgroundJobClient backgroundJobClient = new BackgroundJobClient();
                var producer = new Producer();

                bool produceResult;
                do
                {
                    produceResult = producer.Produce(backgroundJobClient);
                } while (produceResult);
            }
        }
    }
}
