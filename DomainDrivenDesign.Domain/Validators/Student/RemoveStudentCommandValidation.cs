using System;
using System.Collections.Generic;
using System.Text;
using DomainDrivenDesign.Domain.Commands.Student;

namespace DomainDrivenDesign.Domain.Validators.Student
{
    /// <summary>
    ///   删除学生命令验证
    /// </summary>
    public class RemoveStudentCommandValidation:StudentValidation<RemoveStudentCommand>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public RemoveStudentCommandValidation()
        {
            //验证Id
            ValidateId();
        }
    }
}
