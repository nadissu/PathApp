using Business.Domain.Requests;
using Business.Domain.Responses;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IResult Add(AddOrderRequest request);
        IDataResult<GetOrderDetailsResponse> GetOrderDetails(GetOrderRequest request);
        IDataResult<GetOrderDetailsResponse> GetOrderDetailsByCargoId(GetOrderRequest request);
    }

}
