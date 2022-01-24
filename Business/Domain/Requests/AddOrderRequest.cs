using Business.Domain.DTOs;
using System.Collections.Generic;

namespace Business.Domain.Requests
{
    public class AddOrderRequest
    {
        public int UserId { get; set; }
        public List<OrderProductDto> OrderProductList { get; set; }
    }
}
