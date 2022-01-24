using System;

namespace Business.Domain.Responses
{
    public class GetAllProductResponse
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
