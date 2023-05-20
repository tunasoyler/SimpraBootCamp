using FluentValidation;
using SimpraHW1.Api.DTOs;
using SimpraHW1.Core.Repositories;
using SimpraHW1.Data.Repositories;

namespace SimpraHW1.Api.Validators
{
    public class StaffValidator : AbstractValidator<StaffDTO>
    {
        private readonly IStaffRepository staffRepository;

        public StaffValidator(IStaffRepository _staffRepository)
        {
            staffRepository = _staffRepository;

            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(s => s.LastName).NotEmpty().MaximumLength(50);
            RuleFor(s => s.Email).NotEmpty().EmailAddress().Must(BeUniqueEmail);
            RuleFor(s => s.Phone).NotEmpty();
            RuleFor(s => s.DateOfBirth).NotEmpty().Must(BeValidDateOfBirth);
            RuleFor(s => s.AddressLine1).NotEmpty();
            RuleFor(s => s.City).NotEmpty();
            RuleFor(s => s.Country).NotEmpty();
            RuleFor(s => s.Province).NotEmpty();
        }

        private bool BeUniqueEmail(string email)
        {
            var existingStaff = staffRepository.GetByEmail(email);

            if (existingStaff == null)
                return false;
            else
                return true;
        }

        private bool BeValidDateOfBirth(DateTime dateOfBirth)
        {
            return dateOfBirth < DateTime.Now;
        }

    }
}
