namespace Entities.DTOs.Responses
{
    public class OrderDetailsDto
    {
        public int? UserId { get; set; }
        public int? OrderId { get; set; }
        public int? CategoryId { get; set; }
        public int? CargoCompanyId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
