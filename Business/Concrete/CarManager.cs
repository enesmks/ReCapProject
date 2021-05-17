using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Abstracts.Autofac.Caching;
using Core.Abstracts.Autofac.Logging;
using Core.Abstracts.Autofac.Transaction;
using Core.Abstracts.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("admin,customer")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckCountOfCar(car.CarId),MaintenanceTime());
            if (result != null)
            {
                return result;
            }

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
        [SecuredOperation("admin,customer")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(x => x.CarId == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDeails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        [TransactionScopeAspect]
        public IResult Transactionaloperation(Car car)
        {
            _carDal.Add(car);
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("admin,supplier")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
        private IResult CheckCountOfCar(int carId)
        {
            var result = _carDal.GetAll(x => x.CarId == carId);
            if (result.Count>=10)
            {
                return new ErrorResult(Messages.CarLimitExceded);
            }
            return new SuccessResult();
        }
        private IResult MaintenanceTime()
        {
            if (DateTime.Now.Hour>21)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            return new SuccessResult();
        }
    }
}
