using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CryptoBox.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoBox.Repo
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _entities;

        public RepositoryBase(DataContext context)
        {
            this._context = context;
            _entities = context.Set<T>();
        }


        public IEnumerable<T> GetAll()
        {

            return _entities.AsEnumerable();
        }

        public T GetById(int id)
        {
            return _entities.Find(id);
        }
        public T GetByFilter(Expression<Func<T, bool>> filter)
        {

            return _entities.SingleOrDefault(filter);
        }

        public List<T> GetListByFilter(Expression<Func<T, bool>> filter)
        {
            return _entities.Where(filter).ToList();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Add(entity);
            SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Update(entity);
            SaveChanges();
        }

        private void SaveChanges()
        {
            _context.SaveChanges();
        }

        public int GetCount(Expression<Func<T, bool>> filter)
        {
            return _entities.Count(filter);
        }
        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Remove(entity);
            SaveChanges();
        }


    }
}
