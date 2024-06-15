using Autofac;
using Management.WebUI.Business.Abstract;
using Management.WebUI.Business.Concrete;

namespace Management.WebUI.Business.DepencencyResolvers.Autofac
{
    public class AutofacWebUIBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthManagerWebUI>().As<IAuthServiceWebUI>();
        }
    }
}
