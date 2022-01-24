using Business.Domain.Responses;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IShipmentService
    {
        IResult Add(int orderId);
        IDataResult<List<GetAllShipmentResponse>> GetShipmentByCargoCompany();
    }

}
