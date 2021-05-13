using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.EntityFramework.Concrete
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage,ReCapContext>,ICarImageDal
    {

    }
}
