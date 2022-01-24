using Business.Abstract;
using Business.Domain.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("add")]
        public IActionResult Add(AddOrderRequest request)
        {
            var result = _orderService.Add(request);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getorderdetails")]
        public IActionResult GetOrderDetails(GetOrderRequest request)
        {
            var result = _orderService.GetOrderDetails(request);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getorderdetailsbycargoid")]
        public IActionResult GetOrderDetailsByCargoId(GetOrderRequest request)
        {
            var result = _orderService.GetOrderDetailsByCargoId(request);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}
