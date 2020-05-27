using FluentValidation.Results;
using Hahn.ApplicatonProcess.May2020.Domain.Models;
using System.Collections.Generic;

namespace Hahn.ApplicatonProcess.May2020.Domain.Interfaces
{
    public interface IErrorMapper
    {
        ServerResponse MapToError(ServerResponse response, string errorDetail);
        ServerResponse MapToError(ServerResponse response, IList<ValidationFailure> errorDetail);
    }
}
