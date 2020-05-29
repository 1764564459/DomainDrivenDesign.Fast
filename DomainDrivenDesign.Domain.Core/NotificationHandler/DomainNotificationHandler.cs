using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DomainDrivenDesign.Domain.Core.Notifications;
using MediatR;

namespace DomainDrivenDesign.Domain.Core.NotificationHandler
{
    /// <summary>
    /// 领域通知处理程序，把所有的通知信息放到事件总线中
    /// 继承 INotificationHandler<T>
    /// </summary>
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notify;

        public DomainNotificationHandler()
        {
            _notify = new List<DomainNotification>();
        }
        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            _notify.Add(notification);
            return Task.CompletedTask;
        }


        public virtual List<DomainNotification> GetNotify()
        {
            return _notify;
        }

        public void Clear()
        {
            _notify=null;
        }

    }
}
