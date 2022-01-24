using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs.Responses;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, PathAppContext>, IOrderDal
    {
        public List<OrderDetailsDto> GetOrderDetailsByCargoId(int cargoCompanyId)
        {
            using (PathAppContext context = new PathAppContext())
            {
                var result = from order in context.Orders
                             join orderProducts in context.OrderProducts
                             on order.Id equals orderProducts.OrderId
                             join product in context.Products
                             on orderProducts.ProductId equals product.Id
                             join category in context.Categories
                             on product.CategoryId equals category.Id
                             select new OrderDetailsDto
                             {
                                 UserId = order.UserId,
                                 OrderId = order.Id,
                                 CategoryId = category.Id,
                                 CargoCompanyId = category.CargoCompanyId,
                                 ProductName = product.Name,
                                 Quantity = orderProducts.Quantity,
                                 Price = orderProducts.Price
                             };

                return result.Where(x => x.CargoCompanyId == cargoCompanyId).ToList();
            }
        }

        public List<OrderDetailsDto> GetOrderDetailsDto(int orderId)
        {
            using (PathAppContext context = new PathAppContext())
            {
                var result = from order in context.Orders
                             join orderProducts in context.OrderProducts
                             on order.Id equals orderProducts.OrderId
                             join product in context.Products
                             on orderProducts.ProductId equals product.Id
                             join category in context.Categories
                             on product.CategoryId equals category.Id
                             where order.Id == orderId
                             select new OrderDetailsDto
                             {
                                 UserId = order.UserId,
                                 OrderId = orderId,
                                 CategoryId = category.Id,
                                 CargoCompanyId = category.CargoCompanyId,
                                 ProductName = product.Name,
                                 Quantity = orderProducts.Quantity,
                                 Price = orderProducts.Price
                             };

                return result.ToList();
            }
        }
    }

}
