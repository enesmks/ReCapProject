using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfColarDal : EfEntityRepositoryBase<Colar,ReCapContext>,IColarDal
    {

    }
}
