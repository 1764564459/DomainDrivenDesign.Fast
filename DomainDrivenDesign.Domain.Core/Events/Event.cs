using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace DomainDrivenDesign.Domain.Core.Events
{
    public abstract class Event : INotification
    {
        public DateTime? Tick { get; private set; }

        protected Event()
        {
            Tick = DateTime.Now;
        }

    }
}
