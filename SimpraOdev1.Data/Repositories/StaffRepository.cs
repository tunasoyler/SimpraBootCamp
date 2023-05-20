using Microsoft.EntityFrameworkCore;
using SimpraHW1.Core.Entities;
using SimpraHW1.Core.Repositories;
using SimpraHW1.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpraHW1.Data.Repositories
{
    public class StaffRepository : GenericRepository<Staff>, IStaffRepository
    {
        public StaffRepository(DbContext db) : base(db)
        {
        }

        private StaffDb dbContext
        {
            get { return db as StaffDb; }
        }

        public async Task<IEnumerable<Staff>> GetByCity(string city)
        {
            return await dbContext.Staff.Where(x => x.City == city).ToListAsync();
        }

        public async Task<Staff> GetByEmail(string email)
        {
            return await dbContext.Staff.Where(x => x.Email == email).FirstOrDefaultAsync();
        }
    }
}
