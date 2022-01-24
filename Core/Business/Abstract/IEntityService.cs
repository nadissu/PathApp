using Core.Utilities.Results;
using Entities.Abstract;
using System;
using System.Collections.Generic;

namespace Core.Business.Abstract
{
    public interface IEntityService<T> where T : class, IEntity, new()
    {
        IDataResult<List<T>> GetAll(Func<T, bool> filter = null);
        IDataResult<T> Get(Func<T, bool> filter);
        IResult Add(T t);
        IResult Delete(T t);
        IResult Update(T t);
    }
}
