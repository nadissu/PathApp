using Entities.Abstract;

namespace Entities.Concrete
{
    public class CargoCompany : BaseClass, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
