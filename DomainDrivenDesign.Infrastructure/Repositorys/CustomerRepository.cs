using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainDrivenDesign.Domain.Interface;
using DomainDrivenDesign.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Infrastructure.Repositorys
{
    /// <summary>
    /// Customer仓储，操作对象还是领域对象
    /// </summary>
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext context):base(context)
        {
            
        }
        //对特例接口进行实现
        public Customer GetByEmail(string email)
        {
            return  _dbset.FirstOrDefault(p => p.Email == email);
        }
    }
}
