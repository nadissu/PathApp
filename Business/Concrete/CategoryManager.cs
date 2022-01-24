using Business.Abstract;
using Core.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<Category> Get(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(category => category.Id == categoryId));
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), "bla bla");
        }

        public IDataResult<List<CategoryDto>> GetCategoryIdByOrderId(int OrderId)
        {
            var result = _categoryDal.GetCategoryIdByOrderId(OrderId);
            if (result == null)
            {
                return new ErrorDataResult<List<CategoryDto>>(null, Messages.NotListed);
            }
            return new SuccessDataResult<List<CategoryDto>>(result, Messages.Listed);
        }
    }
}
