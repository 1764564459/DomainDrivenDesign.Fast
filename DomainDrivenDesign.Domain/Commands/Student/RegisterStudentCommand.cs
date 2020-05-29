using System;
using System.Collections.Generic;
using System.Text;
using DomainDrivenDesign.Domain.Validators.Student;

namespace DomainDrivenDesign.Domain.Commands.Student
{
    public class RegisterStudentCommand:StudentCommand
    {
        public RegisterStudentCommand(string name, string email, string phone, DateTime birthDate)
        {
            Name = name;
            Phone = phone;
            Email = email;
            BirthDate = birthDate;

        }

        public override bool IsVaild()
        {
            ValidationResult = new RegisterStudentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
