﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfOrderProductDal : EfEntityRepositoryBase<OrderProduct, PathAppContext>, IOrderProductDal
    {
    }

}
