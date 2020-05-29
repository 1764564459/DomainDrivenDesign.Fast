using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DomainDrivenDesign.Domain.Core.Bus;
using DomainDrivenDesign.Domain.Core.Command;
using DomainDrivenDesign.Domain.Core.Events;
using MediatR;

namespace DomainDrivenDesign.Infrastructure.Bus
{
    /// <summary>
    /// 密封中介记忆总线
    /// </summary>
    public sealed class InMemoryMediator : IMediatorHandler
    {
        IMediator _mediator;

        public InMemoryMediator(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            return _mediator.Publish(@event);
        }

        /// <summary>
        /// 实现发送命令
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        public Task SendCommand<T>(T command) where T : CommandBase
        {
            return _mediator.Send(command);
        }
    }
}
