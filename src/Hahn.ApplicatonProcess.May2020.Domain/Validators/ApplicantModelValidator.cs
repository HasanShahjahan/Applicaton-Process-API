using FluentValidation;
using Hahn.ApplicatonProcess.May2020.Domain.Models;
using Hahn.ApplicatonProcess.May2020.Domain.Services;
using System.Threading.Tasks;

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
           
            RuleFor(applicant => applicant.CountryOfOrigin)
               .NotEmpty().WithMessage("Country Of Origin is required.")
               .Must((applicant, domain) => ValidateCountryOfOrigin(applicant.CountryOfOrigin)).WithMessage("Must be a valid Country");

        }

        private bool ValidateCountryOfOrigin(string countryOfOrigin)
        {
            var isValid = Task.Run(() => ClientFactory.GetResult(countryOfOrigin));
            isValid.Wait();
            var flag = isValid.Result;
            return flag;
        }
    }
}
