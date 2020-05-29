using System;
using System.Collections.Generic;
using System.Text;
using DomainDrivenDesign.Domain.Core.Bus;
using DomainDrivenDesign.Domain.Core.Command;
using DomainDrivenDesign.Domain.Core.Notifications;
using DomainDrivenDesign.Domain.Interface;

namespace DomainDrivenDesign.Domain.CommandHandlers
{
    /// <summary>
    /// 领域命令处理程序
    /// 用来作为全部处理程序的基类，提供公共方法和接口数据
    /// </summary>
    public class CommandHandler
    {
        IUnitOfWork _unit;
        IMediatorHandler _mediator;
        public CommandHandler(IUnitOfWork unit,IMediatorHandler mediator)
        {
            _unit = unit;
            _mediator = mediator;
        }

        public bool SaveChanges()
        {
            return _unit.SaveChanges();
        }

        /// <summary>
        /// 消息通知
        /// </summary>
        /// <param name="message"></param>
        protected void NotifyValidationErrors(CommandBase message)
        {
            foreach (var err in message.ValidationResult.Errors)
            {
                _mediator.RaiseEvent(new DomainNotification("",err.ErrorMessage));
            }
        }
    }
}
