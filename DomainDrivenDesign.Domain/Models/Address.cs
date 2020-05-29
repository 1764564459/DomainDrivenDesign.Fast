using DomainDrivenDesign.Domain.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDrivenDesign.Domain.Models
{
    /// <summary>
    /// 地址信息
    /// </summary>
    [Owned]
    public class Address : ValueObject<Address>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="province"></param>
        /// <param name="city"></param>
        /// <param name="county"></param>
        /// <param name="street"></param>
        public Address(string province,string city,string county,string street)
        {
            this.Province = province;
            this.City = city;
            this.County = county;
            this.Street = street;
        }

        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; private set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// 区县
        /// </summary>
        public string County { get; private set; }

        /// <summary>
        /// 街道
        /// </summary>
        public string Street { get; private set; }



        public override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }

        protected override bool EquilsCore(Address obj)
        {
            throw new NotImplementedException();
        }
    }
}
