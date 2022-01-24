using Entities.Abstract;

namespace Entities.Concrete
{
    public class Order : BaseClass, IEntity
    {

        public int Id { get; set; }
        public int UserId { get; set; }
    }

}
