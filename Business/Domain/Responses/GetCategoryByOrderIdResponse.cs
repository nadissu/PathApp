namespace Business.Domain.Responses
{
    public class GetCategoryByOrderIdResponse
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int CategoryId { get; set; }
    }
}
