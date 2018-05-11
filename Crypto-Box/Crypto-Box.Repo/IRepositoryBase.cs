using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CryptoBox.Repo
{
    public interface IRepositoryBase<T>
    {

        IEnumerable<T> GetAll();
        T GetById(int id);
        T GetByFilter(Expression<Func<T, bool>> filter);
        List<T> GetListByFilter(Expression<Func<T, bool>> filter);
        int GetCount(Expression<Func<T, bool>> filter);
        void Insert(T entity);
        void Remove(T entity);
        void Update(T entity);
    }
}
