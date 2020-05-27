using FluentValidation.Results;
using Hahn.ApplicatonProcess.May2020.Domain.Interfaces;
using Hahn.ApplicatonProcess.May2020.Domain.Models;
using System;
using System.Collections.Generic;

namespace Hahn.ApplicatonProcess.May2020.Domain.Mappers
{
    public class ErrorMapper : IErrorMapper
    {
        public ServerResponse MapToError(ServerResponse response, IList<ValidationFailure> errorDetail)
        {
            ServerResponse errorResponse = response;
            errorResponse.RespDesc = string.Empty;
            errorResponse.ErrorDesc = errorDetail;
            return errorResponse;
        }

        public ServerResponse MapToError(ServerResponse response, string errorDetail)
        {
            ServerResponse errorResponse = response;
            errorResponse.ErrorDesc = null;
            errorResponse.RespDesc = errorDetail;
            return errorResponse;
        }
    }
}
