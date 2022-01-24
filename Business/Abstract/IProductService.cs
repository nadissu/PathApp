using Business.Domain.Requests;
using Business.Domain.Responses;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IProductService
    {
        IResult Add(AddProductRequest addProductRequest);
        IDataResult<List<GetAllProductResponse>> GetAll();
        IDataResult<GetAllProductResponse> GetById(GetProductRequest request);
        IDataResult<GetAllProductResponse> GetProductByCategoryId(GetProductRequest request);
    }
}


