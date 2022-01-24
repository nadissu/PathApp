namespace Business.Domain.Requests
{
    public class GetOrderRequest
    {
        public int OrderId { get; set; }
        public int CargoCompanyId { get; set; }
    }
}
