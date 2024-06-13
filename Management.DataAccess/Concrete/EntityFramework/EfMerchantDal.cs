using Management.Core.DataAccess.EntityFramework;
using Management.DataAccess.Abstract;
using Management.DataAccess.Concrete.EntityFramework.Contexts;
using Management.Entity.Concrete;

namespace Management.DataAccess.Concrete.EntityFramework
{
    public class EfMerchantDal : EntityRepositoryBase<MerchantContext, Merchant>, IMerchantDal
    {
    }
}
