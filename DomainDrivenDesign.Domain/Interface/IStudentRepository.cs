using System;
using System.Collections.Generic;
using System.Text;
using DomainDrivenDesign.Domain.Models;

namespace DomainDrivenDesign.Domain.Interface
{
    public interface IStudentRepository:IRepository<Student>
    {
        Student GetByEmial(string email);
    }
}
