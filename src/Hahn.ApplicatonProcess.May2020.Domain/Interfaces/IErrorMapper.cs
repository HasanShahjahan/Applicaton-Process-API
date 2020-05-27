using FluentValidation.Results;
using Hahn.ApplicatonProcess.May2020.Domain.Models;
using System.Collections.Generic;

namespace Hahn.ApplicatonProcess.May2020.Domain.Interfaces
{
    public interface IErrorMapper
    {
        ServerResponse MapToError(ServerResponse response, string errorDetail);
        ServerResponse MapToError(ServerResponse response, IList<ValidationFailure> errorDetail);
        ApplicantModel MapToError(ApplicantModel model, ServerResponse response, string errorDetail);
    }
}
