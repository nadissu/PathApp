using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs.Responses;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IOrderDal : IEntityRepository<Order>
    {
        List<OrderDetailsDto> GetOrderDetailsDto(int orderId);
        List<OrderDetailsDto> GetOrderDetailsByCargoId(int cargoCompanyId);
    }
}
