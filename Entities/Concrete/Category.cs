using Entities.Abstract;

namespace Entities.Concrete
{
    public class Category : BaseClass, IEntity
    {
        public int Id { get; set; }
        public int CargoCompanyId { get; set; }
        public string Name { get; set; }
    }
}
