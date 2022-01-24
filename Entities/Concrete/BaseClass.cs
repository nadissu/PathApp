using System;

namespace Entities.Concrete
{

    public abstract class BaseClass
    {
        public BaseClass()
        {
            CreatedDate = DateTime.Now;
            IsActive = true;
            IsDelete = false;
        }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
