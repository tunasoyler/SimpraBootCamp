using SimpraHW1.Core.Repositories;
using SimpraHW1.Core.UnitOfWork;
using SimpraHW1.Data.Context;
using SimpraHW1.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpraHW1.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StaffDb db;
        private StaffRepository staffRepository;

        public UnitOfWork(StaffDb _db)
        {
            db = _db;
        }
        public IStaffRepository Staff => staffRepository = staffRepository ?? new StaffRepository(db);


        public async Task<int> CommitAsync()
        {
            return await db.SaveChangesAsync();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
