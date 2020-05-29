using System;
using System.Collections.Generic;
using System.Text;
using DomainDrivenDesign.Domain.Core.Events;

namespace DomainDrivenDesign.Domain.Events.Student
{
    public class RemoveStudentEvent:Event
    {
        public RemoveStudentEvent(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
