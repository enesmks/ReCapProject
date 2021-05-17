using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int carId);
        IDataResult<List<CarDetailDto>> GetCarDeails();
        IResult Transactionaloperation(Car car);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
    }
}
