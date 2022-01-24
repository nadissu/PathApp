namespace Business.Domain.Requests
{
    public class AddProductRequest
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
    public class AddCategoryRequest
    {
        public string Name { get; set; }
    }

    public class AddCargoCompanyRequest
    {

    }
}
