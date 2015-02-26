using Autofac;

namespace Nsha.Web.Plumbing
{
    public static class IoC
    {
        public static IContainer LetThereBeIoC()
        {
            var builder = new ContainerBuilder();

            var assemblies = new[]
            {
                typeof (IoC).Assembly
            };

            builder.RegisterAssemblyModules(assemblies);

            return builder.Build();
        }
    }
}
