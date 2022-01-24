using Business.Abstract;
using Core.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CargoCompanyManager : ICargoCompanyService
    {
        private readonly ICargoCompanyDal _cargoCompanyDal;

        public CargoCompanyManager(ICargoCompanyDal cargoCompanyDal)
        {
            _cargoCompanyDal = cargoCompanyDal;
        }

        public IDataResult<List<CargoCompany>> GetAll()
        {
            var result = _cargoCompanyDal.GetAll();
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<CargoCompany>>(null, Messages.NotListed);
            }
            return new SuccessDataResult<List<CargoCompany>>(result);
        }
    }
}
