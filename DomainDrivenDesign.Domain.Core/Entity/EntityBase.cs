using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDrivenDesign.Domain.Core.Entity
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }

        public DateTime CreateTime { get; set; }

        public string CreatUser { get; set; }

        public DateTime ModifyTime { get; set; }

        public string ModifyUser { get; set; }
    }
}
