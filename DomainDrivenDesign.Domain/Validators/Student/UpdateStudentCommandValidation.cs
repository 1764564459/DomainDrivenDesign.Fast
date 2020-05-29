using System;
using System.Collections.Generic;
using System.Text;
using DomainDrivenDesign.Domain.Commands.Student;

namespace DomainDrivenDesign.Domain.Validators.Student
{
    /// <summary>
    /// 修改学生验证
    /// </summary>
    public class UpdateStudentCommandValidation:StudentValidation<UpdateStudentCommand>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public UpdateStudentCommandValidation()
        {
            ValidateBirthDate();
            ValidateEmail();
            ValidateId();
            ValidateName();
            ValidatePhone();
        }
    }
}
