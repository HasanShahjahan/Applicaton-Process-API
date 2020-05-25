using FluentValidation;
using Hahn.ApplicatonProcess.May2020.Domain.Models;

namespace Hahn.ApplicatonProcess.May2020.Domain.Validators
{
    public class ApplicantModelValidator : AbstractValidator<ApplicantModel>
    {
        public ApplicantModelValidator()
        {
            RuleFor(applicant => applicant.Name)
                .NotEmpty().WithMessage("Name is required")
                .MinimumLength(5).WithMessage("Name should have at least 5 Characters.");

            RuleFor(applicant => applicant.FamilyName)
               .NotEmpty().WithMessage("Family Name is required")
               .MinimumLength(5).WithMessage("Family Name should have at least 5 Characters.");

            RuleFor(applicant => applicant.Address)
               .NotEmpty().WithMessage("Address is required")
               .MinimumLength(10).WithMessage("Address should have at least 10 Characters.");

            RuleFor(applicant => applicant.EMailAdress)
                .NotEmpty().WithMessage("Email address is required.")
                .EmailAddress().WithMessage("A valid email is required.");

            RuleFor(applicant => applicant.Age)
                .NotEmpty().WithMessage("Age is required.")
                .Must((model, Age) => Age >= 20 && Age <= 60).WithMessage("Age must be between 20 and 60");

        }
    }
}
