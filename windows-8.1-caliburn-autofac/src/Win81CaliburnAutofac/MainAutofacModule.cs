using Autofac;
using Caliburn.Micro;

namespace Win81CaliburnAutofac
{
    public class MainAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(IoC.Assemblies)
                .Where(x => x.Name.EndsWith("ViewModel"))
                .AsSelf()
                .InstancePerDependency();
            builder.RegisterAssemblyTypes(IoC.Assemblies)
                .Where(t => t.Name.EndsWith("View"))
                .AsSelf()
                .InstancePerDependency();

            builder.RegisterType<EventAggregator>().AsImplementedInterfaces().SingleInstance();
            builder.Register(c => new FrameAdapter(IoC.Frame)).AsImplementedInterfaces().InstancePerDependency();
        }
    }
}