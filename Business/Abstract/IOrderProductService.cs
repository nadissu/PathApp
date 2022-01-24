using Business.Domain.Requests;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IOrderProductService
    {
        IResult Add(AddOrderProductRequest request);
    }

}
