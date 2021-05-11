using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IColarService
    {
        IDataResult<List<Colar>> GetAll();
        IDataResult<Colar> GetById(int colarId);
        IResult Add(Colar colar);
        IResult Update(Colar colar);
        IResult Delete(Colar colar);
    }
}
