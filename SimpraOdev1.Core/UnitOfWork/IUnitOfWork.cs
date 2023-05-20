using SimpraHW1.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpraHW1.Core.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IStaffRepository Staff { get; }
        Task<int> CommitAsync();
    }
}
