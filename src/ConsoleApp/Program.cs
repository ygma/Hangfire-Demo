using System;
using Autofac;
using ClassLibrary;
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

            IContainer container = BuildContainer();
            GlobalConfiguration.Configuration.UseAutofacActivator(container);

//            const string baseUri = "http://localhost:9000";
//            using (WebApp.Start<Startup>(baseUri))
//            {
//                RecurringJob
                while (true)
                {
                    var line = Console.ReadLine();
                    var backgroundJobClient = container.Resolve<IBackgroundJobClient>();
                    backgroundJobClient.Enqueue<SomeService>(s => s.Print(line));
                }
//            }
            
        }

        static IContainer BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<SomeService>();
            containerBuilder.RegisterType<BackgroundJobClient>().As<IBackgroundJobClient>();

            IContainer container = containerBuilder.Build();
            return container;
        }
    }
}
