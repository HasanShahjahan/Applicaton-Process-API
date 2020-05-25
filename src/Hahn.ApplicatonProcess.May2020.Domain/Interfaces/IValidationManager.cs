using FluentValidation;
using FluentValidation.Results;

namespace Hahn.ApplicatonProcess.May2020.Domain.Interfaces
{
    public interface IValidationManager
    {
        ValidationResult Validate(IValidator validator, object entity);
    }
}
