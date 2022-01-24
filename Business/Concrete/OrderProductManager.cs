using AutoMapper;
using Business.Abstract;
using Business.Domain.Requests;
using Core.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class OrderProductManager : IOrderProductService
    {
        private readonly IOrderProductDal _orderProductDal;
        private readonly IMapper _mapper;

        public OrderProductManager(IOrderProductDal orderProductDal, IMapper mapper)
        {
            _orderProductDal = orderProductDal;
            _mapper = mapper;
        }

        public IResult Add(AddOrderProductRequest request)
        {
            if (request == null)
            {
                return new ErrorResult(Messages.NotAdded);
            }

            OrderProduct orderProduct = _mapper.Map<OrderProduct>(request);
            _orderProductDal.Add(orderProduct);

            return new SuccessResult(Messages.Added);
        }
    }
}
