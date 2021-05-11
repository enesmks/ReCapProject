using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Abstracts.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ColarManager : IColarService
    {
        IColarDal _colarDal;
        private string ColarDeleted;
        private string ColarUpdated;

        public ColarManager(IColarDal colarDal)
        {
            _colarDal = colarDal;
        }

        [ValidationAspect(typeof(ColarValidator))]
        public IResult Add(Colar colar)
        {
            _colarDal.Add(colar);
            return new SuccessResult(Messages.ColarAdded);
        }

        public IResult Delete(Colar colar)
        {
            _colarDal.Delete(colar);
            return new SuccessResult(ColarDeleted);
        }

        public IDataResult<List<Colar>> GetAll()
        {
            return new SuccessDataResult<List<Colar>>(_colarDal.GetAll());
        }

        public IDataResult<Colar> GetById(int colarId)
        {
            return new SuccessDataResult<Colar>(_colarDal.Get(x => x.ColarId == colarId));
        }

        [ValidationAspect(typeof(ColarValidator))]
        public IResult Update(Colar colar)
        {
            _colarDal.Update(colar);
            return new SuccessResult(ColarUpdated);
        }
    }
}
