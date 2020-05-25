using FluentValidation;
using FluentValidation.Results;
using Hahn.ApplicatonProcess.May2020.Domain.Interfaces;

namespace Hahn.ApplicatonProcess.May2020.Domain.Managers
{
    public class ValidationManager : IValidationManager
    {
        public ValidationResult Validate(IValidator validator, object entity)
        {
            var result = validator.Validate(entity);
            return result;
        }
    }
}
