using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Igp.Business.Common.UnitOfWork
{
    interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
