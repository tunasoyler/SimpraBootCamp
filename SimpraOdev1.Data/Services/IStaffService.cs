using SimpraHW1.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpraHW1.Data.Services
{
    public interface IStaffService
    {
        Task<IEnumerable<Staff>> GetAllStaff();
        Task<Staff> GetStaffById(int id);
        Task<Staff> CreateStaff(Staff staff);
        Task UpdateStaff(Staff staffToBeUpdated, Staff staff);
        Task DeleteStaff(Staff staff);
    }
}
