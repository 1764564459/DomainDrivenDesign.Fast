using System;
using System.Collections.Generic;
using System.Text;
using DomainDrivenDesign.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainDrivenDesign.Infrastructure.Mappings
{
    public class StudentMap : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.Phone).HasMaxLength(20);
            builder.Property(p => p.Email).HasMaxLength(50);

            //如果想忽略当前值对象，可直接 Ignore
            //builder.Ignore(c => c.Address);

            //处理值对象【//记得在 Address 值对象上增加一个 [Owned] 特性】
            builder.OwnsOne(p => p.Address, p =>
            {
                p.Property(o => o.City).HasMaxLength(50).HasColumnName("City");
                p.Property(o => o.County).HasMaxLength(50).HasColumnName("County"); ;
                p.Property(o => o.Street).HasMaxLength(50).HasColumnName("Street"); ;
                p.Property(o => o.Province).HasMaxLength(50).HasColumnName("Province"); ;
            });
        }
    }
}
