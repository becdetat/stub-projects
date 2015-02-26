using Autofac;

namespace Nsha.Web.Plumbing
{
    public class Bootstrapper : AutofacNancyBootstrapper
    {
        public Bootstrapper(ILifetimeScope scope)
            : base(scope)
        {
        }
    }
}