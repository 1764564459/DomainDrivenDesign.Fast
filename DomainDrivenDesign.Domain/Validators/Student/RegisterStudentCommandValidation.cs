using System;
using System.Collections.Generic;
using System.Text;
using DomainDrivenDesign.Domain.Commands.Student;

namespace DomainDrivenDesign.Domain.Validators.Student
{

    /// <summary>
    /// 用户新增命令验证
    /// </summary>
    public class RegisterStudentCommandValidation:StudentValidation<RegisterStudentCommand>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public RegisterStudentCommandValidation()
        {
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();
            ValidateId();
        }
    }
}
