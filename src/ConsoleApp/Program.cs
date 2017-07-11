using System.ComponentModel;
using Autofac;
using ClassLibrary;
using Hangfire;
using Microsoft.Owin.Hosting;
using IContainer = Autofac.IContainer;

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

            var url = "http://localhost:9000";

            using (WebApp.Start<Startup>(url))
            {
                var producer = container.Resolve<Producer>();

                bool produceResult;
                do
                {
                    produceResult = producer.Produce();
                } while (produceResult);
            }
        }

        static IContainer BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<BackgroundJobClient>().As<IBackgroundJobClient>();
            containerBuilder.RegisterType<Producer>();
            containerBuilder.RegisterModule<ClassLibraryModule>();

            IContainer container = containerBuilder.Build();
            return container;
        }
    }
}
