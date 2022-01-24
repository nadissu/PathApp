using Entities.Abstract;
#nullable disable
namespace Entities.Concrete
{
    public class Address : BaseClass, IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string AddressDescription { get; set; }
    }
}
