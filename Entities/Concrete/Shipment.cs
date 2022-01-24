using Entities.Abstract;
using Entities.Enums;

namespace Entities.Concrete
{
    public class Shipment : BaseClass, IEntity
    {
        public int Id { get; set; }
        public int CargoCompanyId { get; set; }
        public int OrderId { get; set; }
        public ShipmentStatus Status { get; set; }
        public string TrackingCode { get; set; }

    }
}
