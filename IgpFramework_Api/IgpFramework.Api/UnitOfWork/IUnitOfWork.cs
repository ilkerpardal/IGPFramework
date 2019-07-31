using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IgpFramework.Api.UnitOfWork
{
    interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
