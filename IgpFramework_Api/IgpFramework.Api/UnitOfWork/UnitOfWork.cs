using IgpFramework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IgpFramework.Api.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IGPCoreContext _context;

        public UnitOfWork(IGPCoreContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
