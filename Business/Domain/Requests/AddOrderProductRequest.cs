namespace Business.Domain.Requests
{
    public class AddOrderProductRequest
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int SourceProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
