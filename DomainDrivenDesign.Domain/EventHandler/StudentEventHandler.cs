using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DomainDrivenDesign.Domain.Events.Student;
using MediatR;

namespace DomainDrivenDesign.Domain.EventHandler
{
    public class StudentEventHandler : INotificationHandler<RegisterStudentEvent>, INotificationHandler<UpdateStudentEvent>, INotificationHandler<RemoveStudentEvent>
    {
        public Task Handle(UpdateStudentEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(RegisterStudentEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(RemoveStudentEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;

        }
    }
}
