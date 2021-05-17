using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.EntityFramework.Concrete
{
    public class EfCreditCardDal : EfEntityRepositoryBase<CreditCard,ReCapContext>,ICreditCardDal
    {

    }
}
