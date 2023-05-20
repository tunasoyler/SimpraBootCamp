using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpraHW1.Api.DTOs;
using SimpraHW1.Api.Validators;
using SimpraHW1.Core.Entities;
using SimpraHW1.Core.Repositories;
using SimpraHW1.Data.Services;

namespace SimpraHW1.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private IStaffService staffService;
        private IStaffRepository staffRepository;
        private IMapper mapper;

        public StaffController(IMapper _mapper, IStaffService _staffService)
        {
            mapper = _mapper;
            staffService = _staffService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StaffDTO>>> GetAll()
        {
            var staff = await staffService.GetAllStaff();

            var staffRes = mapper.Map<IEnumerable<Staff>, IEnumerable<StaffDTO>>(staff);
            return Ok(staffRes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StaffDTO>> GetById(int id)
        {
            var staff = await staffService.GetStaffById(id);

            var staffRes = mapper.Map<Staff, StaffDTO>(staff);

            return Ok(staffRes);
        }

        [HttpPost]
        public async Task<ActionResult<StaffDTO>> Post(StaffDTO staffDTO)
        {
            var validator = new StaffValidator(staffRepository);
            var validationResult = await validator.ValidateAsync(staffDTO);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);


            var staffToCreate = mapper.Map<StaffDTO, Staff>(staffDTO);
            var newStaff = await staffService.CreateStaff(staffToCreate);

            var staff = await staffService.GetStaffById(newStaff.Id);

            var staffRes = mapper.Map<Staff, StaffDTO>(staff);
            return Ok(staffRes);
        }

        [HttpPut("id")]
        public async Task<ActionResult<StaffDTO>> Put(int id, StaffDTO staffDTO)
        {
            var validator = new StaffValidator(staffRepository);
            var validationResult = await validator.ValidateAsync(staffDTO);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);


            var staffToUpdate = await staffService.GetStaffById(id);

            if (staffToUpdate == null)
                return NotFound();

            var staff = mapper.Map<StaffDTO, Staff>(staffDTO);

            await staffService.UpdateStaff(staffToUpdate, staff);

            var updatedStaff = await staffService.GetStaffById(staffToUpdate.Id);

            var updatedStaffRes = mapper.Map<Staff, StaffDTO>(updatedStaff);

            return Ok(updatedStaffRes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            var staff = await staffService.GetStaffById(id);

            if (staff == null)
                return NotFound();

            await staffService.DeleteStaff(staff);

            return NoContent();
        }

        
    }
}
