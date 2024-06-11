using Management.Core.DataAccess;
using Management.Entity.Concrete;

namespace Management.DataAccess.Abstract
{
    public interface IMerchantDal : IEntityRepository<MerchantDto>
    {
    }
}
