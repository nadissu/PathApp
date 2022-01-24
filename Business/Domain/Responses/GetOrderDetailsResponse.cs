using Entities.DTOs.Responses;
using System.Collections.Generic;

namespace Business.Domain.Responses
{
    public class GetOrderDetailsResponse
    {
        public List<UserDetailsDto> userDetails { get; set; }
        public List<OrderDetailsDto> orderDetailsDto { get; set; }
    }
}
