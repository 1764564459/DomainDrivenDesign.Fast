using DomainDrivenDesign.Domain.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDrivenDesign.Domain.Models
{
    public class Student:EntityBase
    {
        public Student(string name,string email,string phone,DateTime birthdate,Address address )
        {
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; private set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Phone { get; private set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime BirthDate { get; private set; }

        /// <summary>
        /// 地址
        /// </summary>
        public Address Address { get; set; }
    }
}
