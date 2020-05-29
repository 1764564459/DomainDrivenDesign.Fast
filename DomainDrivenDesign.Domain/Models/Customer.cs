using System;
using System.Collections.Generic;
using System.Text;
using DomainDrivenDesign.Domain.Core.Entity;

namespace DomainDrivenDesign.Domain.Models
{
    /// <summary>
    /// 定义领域对象 Customer
    /// </summary>
    public class Customer:EntityBase
    {
        protected Customer() { }
        public Customer(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
    }
}
