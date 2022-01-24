namespace Business.Domain.DTOs
{
    public class OrderProductDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int SourceProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
