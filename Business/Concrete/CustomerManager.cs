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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [SecuredOperation("admin,supplier")]
        [CacheRemoveAspect("ICustomer.Get")]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }
        [SecuredOperation("admin,supplier")]
        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(x => x.CustomerId == customerId));
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Customer customer)
        {
            _customerDal.Add(customer);
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [SecuredOperation("admin,supplier")]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
