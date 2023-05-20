using SimpraHW1.Core.Entities;
using SimpraHW1.Core.UnitOfWork;
using SimpraHW1.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpraHW1.Services.Services
{
    public class StaffService : IStaffService
    {
        private readonly IUnitOfWork unitOfWork;

        public StaffService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<Staff> CreateStaff(Staff staff)
        {
            await unitOfWork.Staff.AddAsync(staff);
            await unitOfWork.CommitAsync();
            return staff;
        }

        public async Task DeleteStaff(Staff staff)
        {
            await unitOfWork.Staff.Remove(staff);
            await unitOfWork.CommitAsync();
        }

        public Task<IEnumerable<Staff>> GetAllStaff()
        {
            return unitOfWork.Staff.GetAllAsync();
        }

        public async Task<Staff> GetStaffById(int id)
        {
            return await unitOfWork.Staff.GetByIdAsync(id);
        }

        public async Task UpdateStaff(Staff staffToBeUpdated, Staff staff)
        {
            staffToBeUpdated.FirstName = staff.FirstName;
            staffToBeUpdated.LastName = staff.LastName;
            staffToBeUpdated.Email = staff.Email;
            staffToBeUpdated.Phone = staff.Phone;
            staffToBeUpdated.DateOfBirth = staff.DateOfBirth;
            staffToBeUpdated.AddressLine1 = staff.AddressLine1;
            staffToBeUpdated.City = staff.City;
            staffToBeUpdated.Country = staff.Country;
            staffToBeUpdated.Province = staff.Province;

            await unitOfWork.CommitAsync();
        }
    }
}
