using Autofac;

namespace ClassLibrary
{
    public class ClassLibraryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<Consumer>();
            builder.RegisterType<Dependency>();
        }
    }
}