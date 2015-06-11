using System.Reflection;
using Windows.UI.Xaml.Controls;
using Autofac;
using Autofac.Builder;

namespace Win81CaliburnAutofac
{
    public static class IoC
    {
        public static Assembly[] Assemblies
        {
            get
            {
                return new[]
                {
                    typeof (IoC).GetTypeInfo().Assembly
                };
            }
        }

        public static Frame Frame { get; set; }

        public static IContainer LetThereBeIoC(ContainerBuildOptions options = ContainerBuildOptions.None)
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(Assemblies);

            return builder.Build(options);
        }
    }
}