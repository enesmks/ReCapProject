using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.EntityFramework.Concrete
{
    public class EfColarDal : EfEntityRepositoryBase<Colar,ReCapContext>,IColarDal
    {

    }
}
