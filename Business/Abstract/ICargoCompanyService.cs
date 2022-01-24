using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICargoCompanyService
    {
        IDataResult<List<CargoCompany>> GetAll();
    }

}
