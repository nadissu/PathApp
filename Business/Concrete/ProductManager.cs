using AutoMapper;
using Business.Abstract;
using Business.Domain.Requests;
using Business.Domain.Responses;
using Core.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IMapper _mapper;

        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        public IResult Add(AddProductRequest addProductRequest)
        {
            if (addProductRequest == null)
            {
                return new ErrorResult();
            }

            Product product = _mapper.Map<Product>(addProductRequest);
            _productDal.Add(product);

            return new SuccessResult(Messages.Added);
        }

        public IDataResult<List<GetAllProductResponse>> GetAll()
        {
            var result = _productDal.GetAll();
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<GetAllProductResponse>>(null, Messages.NotListed);
            }

            List<GetAllProductResponse> response = _mapper.Map<List<GetAllProductResponse>>(result);

            return new SuccessDataResult<List<GetAllProductResponse>>(response, Messages.Listed);
        }

        public IDataResult<GetAllProductResponse> GetById(GetProductRequest request)
        {
            var result = _productDal.Get(product => product.Id == request.Id);
            if (result == null)
            {
                return new ErrorDataResult<GetAllProductResponse>(null, Messages.NotListed);
            }

            GetAllProductResponse response = _mapper.Map<GetAllProductResponse>(result);

            return new SuccessDataResult<GetAllProductResponse>(response, Messages.Listed);
        }

        public IDataResult<GetAllProductResponse> GetProductByCategoryId(GetProductRequest request)
        {
            var result = _productDal.Get(product => product.CategoryId == request.Id);
            if (result == null)
            {
                return new ErrorDataResult<GetAllProductResponse>(null, Messages.NotListed);
            }

            GetAllProductResponse response = _mapper.Map<GetAllProductResponse>(result);

            return new SuccessDataResult<GetAllProductResponse>(response, Messages.Listed);
        }
    }
}
