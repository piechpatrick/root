﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Butterfly.MultiPlatform.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IRepository<TEntity> SetSource(IRepository<TEntity> repository);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity Add(TEntity entity);
        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);

        TEntity Remove(TEntity entity);
        IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> entities);
    }
}
