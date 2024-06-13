using Autofac;
using Management.Business.Abstract;
using Management.Business.Concrete;
using Management.DataAccess.Abstract;
using Management.DataAccess.Concrete.EntityFramework;

namespace Management.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<EfMerchantDal>().As<IMerchantDal>();
        }
    }
}
