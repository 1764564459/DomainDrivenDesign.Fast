using System;
using System.Collections.Generic;
using System.Text;
using DomainDrivenDesign.Domain.Core.Events;

namespace DomainDrivenDesign.Domain.Core.Notifications
{
    /// <summary>
    /// 领域通知模型，用来获取当前总线中出现的通知信息
    /// 继承自领域事件和 INotification（也就意味着可以拥有中介的发布/订阅模式）
    /// </summary>
    public class DomainNotification:Event
    {
        public Guid Id { get; private set; }

        public string Key { get; private set; }

        public string Value { get; private set; }

        public int Version { get; private set; }

        public DomainNotification(string key,string value)
        {
            Key = key;
            Value = value;
            Version = 1;
            Id = Guid.NewGuid();
        }
    }
}
