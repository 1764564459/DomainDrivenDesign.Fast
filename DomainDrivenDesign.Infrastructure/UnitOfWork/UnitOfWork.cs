using System;
using System.Collections.Generic;
using System.Text;
using DomainDrivenDesign.Domain.Interface;
using DomainDrivenDesign.Infrastructure.Repositorys;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Infrastructure.UnitOfWork
{
    /// <summary>
    /// 工作单元
    /// </summary>
    public class UnitOfWork<TContext> : IUnitOfWork where TContext:DbContext
    {
        private readonly DbContext _context;

        
        public UnitOfWork(TContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 获取仓储
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public Repository<TEntity> Repository<TEntity>() where TEntity :class
        {
            return new Repository<TEntity>(_context);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        /// <summary>
        /// 回收
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
