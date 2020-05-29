using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DomainDrivenDesign.Domain.Core.Command;
using DomainDrivenDesign.Domain.Core.Events;

namespace DomainDrivenDesign.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : CommandBase;

        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
