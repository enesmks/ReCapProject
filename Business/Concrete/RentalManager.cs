using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Abstracts.Autofac.Caching;
using Core.Abstracts.Autofac.Transaction;
using Core.Abstracts.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        [SecuredOperation("admin,supplier")]
        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult();
        }
        [SecuredOperation("admin,supplier")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(x => x.RentalId == rentalId));
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Rental rental)
        {
            _rentalDal.Add(rental);
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
        [ValidationAspect(typeof(RentalValidator))]
        [SecuredOperation("admin,supplier")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}
