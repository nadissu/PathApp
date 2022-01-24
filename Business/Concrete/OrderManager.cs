using AutoMapper;
using Business.Abstract;
using Business.Domain.Requests;
using Business.Domain.Responses;
using Core.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Responses;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;
        private readonly IOrderProductService _orderProductService;
        private readonly IShipmentService _shipmentService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public OrderManager(IOrderDal orderDal, IMapper mapper, IOrderProductService orderProductService, IShipmentService shipmentService,
            IUserService userService)
        {
            _orderDal = orderDal;
            _mapper = mapper;
            _orderProductService = orderProductService;
            _shipmentService = shipmentService;
            _userService = userService;
        }

        public IResult Add(AddOrderRequest request)
        {
            if (request == null)
            {
                return new ErrorResult(Messages.NotAdded);
            }

            Order order = _mapper.Map<Order>(request);

            _orderDal.Add(order);

            foreach (var item in request.OrderProductList)
            {
                item.OrderId = order.Id;
                AddOrderProductRequest addOrderProductRequest = _mapper.Map<AddOrderProductRequest>(item);
                _orderProductService.Add(addOrderProductRequest);
            }

            _shipmentService.Add(order.Id);

            return new SuccessResult(Messages.Added);
        }

        public IDataResult<GetOrderDetailsResponse> GetOrderDetails(GetOrderRequest request)
        {
            GetOrderDetailsResponse response = new GetOrderDetailsResponse();

            response.orderDetailsDto = _mapper.Map<List<OrderDetailsDto>>(_orderDal.GetOrderDetailsDto(request.OrderId));

            foreach (var item in response.orderDetailsDto)
            {
                response.userDetails = _mapper.Map<List<UserDetailsDto>>(_userService.GetUserDetailsDto(item.UserId).Data);
            }

            return new SuccessDataResult<GetOrderDetailsResponse>(response);
        }

        public IDataResult<GetOrderDetailsResponse> GetOrderDetailsByCargoId(GetOrderRequest request)
        {
            GetOrderDetailsResponse response = new GetOrderDetailsResponse();

            response.orderDetailsDto = _mapper.Map<List<OrderDetailsDto>>(_orderDal.GetOrderDetailsByCargoId(request.CargoCompanyId));

            foreach (var item in response.orderDetailsDto)
            {
                response.userDetails = _mapper.Map<List<UserDetailsDto>>(_userService.GetUserDetailsDto(item.UserId).Data);
            }

            return new SuccessDataResult<GetOrderDetailsResponse>(response);
        }
    }
}
