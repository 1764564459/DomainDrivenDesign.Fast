using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDrivenDesign.Domain.Interface
{
    /// <summary>
    /// 工作单元    
    /// </summary>
    public interface IUnitOfWork:IDisposable 
    {
        bool SaveChanges();
    }
}
