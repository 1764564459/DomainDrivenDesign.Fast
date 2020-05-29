using System;
using System.Collections.Generic;
using System.Text;
using DomainDrivenDesign.Domain.Validators.Student;

namespace DomainDrivenDesign.Domain.Commands.Student
{

    /// <summary>
    /// 学生更新命令
    /// </summary>
    public class UpdateStudentCommand : StudentCommand
    {
        public UpdateStudentCommand(Guid Id, string Name,string Phone,string Email,DateTime BirthDate)
        {
            base.Id = Id;
            base.Name = Name;
            base.Phone = Phone;
            base.Email = Email;
            base.BirthDate = BirthDate;
        }
        public override bool IsVaild()
        {
            ValidationResult = new UpdateStudentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
