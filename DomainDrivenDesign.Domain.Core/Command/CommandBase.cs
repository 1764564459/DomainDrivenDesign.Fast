using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace DomainDrivenDesign.Domain.Core.Command
{
    /// <summary>
    /// 命令抽象基类
    /// </summary>
    public abstract class CommandBase:IRequest
    {
        /// <summary>
        /// 验证日期
        /// </summary>
        public DateTime ValidTime { get; set; }

        public ValidationResult ValidationResult { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        protected CommandBase()
        {
            ValidTime = DateTime.Now;
        }

        /// <summary>
        /// 抽象方法、是否验证
        /// </summary>
        /// <returns></returns>
        public abstract bool IsVaild();

    }
}
