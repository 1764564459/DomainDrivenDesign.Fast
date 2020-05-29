using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Web.Models
{
    /// <summary>
    /// Customer 领域对象
    /// </summary>
    public class Customer
    {
        protected Customer()
        {
        }

        public Customer(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
    }

    /// <summary>
    /// 领域对象持久化层
    /// </summary>
    public class CustomerDao
    {
        public static Customer GetCustomer(string id)
        {
            return new Customer(Guid.NewGuid(), "Christ", "Christ@123.com",DateTime.Now) ;
        }


        public static string SaveCustomer(Customer customer)
        {
            return "保存成功";
        }
    }
}
