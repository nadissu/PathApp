using Entities.Abstract;

namespace Entities.Concrete
{
    public class Product : BaseClass, IEntity
    {

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
