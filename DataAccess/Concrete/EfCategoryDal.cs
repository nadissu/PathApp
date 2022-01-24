using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, PathAppContext>, ICategoryDal
    {
        public List<CategoryDto> GetCategoryIdByOrderId(int OrderId)
        {
            using (PathAppContext context = new PathAppContext())
            {
                var result = from orderProducts in context.OrderProducts
                             join products in context.Products
                             on orderProducts.ProductId equals products.Id
                             join category in context.Categories
                             on products.CategoryId equals category.Id
                             where orderProducts.OrderId == OrderId
                             group category by products.CategoryId into orderProductsGroup
                             select new CategoryDto
                             {
                                 CategoryId = orderProductsGroup.Key,
                                 OrderId = OrderId
                             };
                return result.ToList();
            }
        }
    }
}
