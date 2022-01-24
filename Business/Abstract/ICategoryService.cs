using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<CategoryDto>> GetCategoryIdByOrderId(int OrderId);
        IDataResult<Category> Get(int categoryId);
        IDataResult<List<Category>> GetAll();
    }

}
