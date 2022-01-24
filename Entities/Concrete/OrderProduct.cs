using Entities.Abstract;

namespace Entities.Concrete
{
    public class OrderProduct : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SourceProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
