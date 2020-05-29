using DomainDrivenDesign.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Infrastructure.Repositorys
{
    /// <summary>
    /// 泛型仓储，实现泛型仓储接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity:class
    {
        DbContext _context;
        protected DbSet<TEntity> _dbset;
        public Repository(DbContext context)
        {
            _context = context;
            _dbset = _context.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public TEntity GetById(Guid id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Remove(Guid id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            _context.Set<TEntity>().Remove(entity);
        }

        public int SaveChanges()
        {
            return  _context.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _context.Set<TEntity>().Update(obj);
        }
    }
}
