using System;
using System.Collections.Generic;
using System.Text;
using DomainDrivenDesign.Domain.Validators.Student;

namespace DomainDrivenDesign.Domain.Commands.Student
{
    public class RemoveStudentCommand : StudentCommand
    {
        public RemoveStudentCommand(Guid Id)
        {
            base.Id = Id;
        }
        public override bool IsVaild()
        {
            ValidationResult = new RemoveStudentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
