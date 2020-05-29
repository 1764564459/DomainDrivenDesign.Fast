using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainDrivenDesign.Domain.Interface;
using DomainDrivenDesign.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Infrastructure.Repositorys
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(DbContext context):base(context)
        {
            
        }
        public Student GetByEmial(string email)
        {
            return   _dbset.AsNoTracking().FirstOrDefault(p => p.Email == email);
        }
    }
}
