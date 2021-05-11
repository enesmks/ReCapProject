using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System.Collections.Generic;

namespace DataAccess.Concrete
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (var context = new ReCapContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join colar in context.Colars
                             on car.ColarId equals colar.ColarId
                             select new CarDetailDto
                             {
                                 BrandId = brand.BrandId,
                                 BrandName = brand.BrandName,
                                 CarId = car.CarId,
                                 CarName = car.CarName,
                                 ColarId = colar.ColarId,
                                 ColarName = colar.ColarName,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 ModelYear = car.ModelYear
                             };
                return result.ToList();
            }
        }
    }
}
