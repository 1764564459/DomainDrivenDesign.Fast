using System;
using System.Collections.Generic;
using System.Text;
using DomainDrivenDesign.Application.ViewModel;

namespace DomainDrivenDesign.Application.Interface
{
    public interface IStudentAppService
    {
        void Register(StudentViewModel customerViewModel);
        IEnumerable<StudentViewModel> GetAll();
        StudentViewModel GetById(Guid id);
        void Update(StudentViewModel customerViewModel);
        void Remove(Guid id);

        //StudentViewModel GetByEmail(string email);
    }
}
