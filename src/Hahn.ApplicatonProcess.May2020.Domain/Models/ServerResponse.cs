using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.May2020.Domain.Models
{
    public class ServerResponse 
    {
        public static ServerResponse OK = new ServerResponse { RespCode = 201 };
        public static ServerResponse ERROR = new ServerResponse { RespCode = 500 };
        public static ServerResponse BadRequest = new ServerResponse { RespCode = 400 };
        public static ServerResponse Unauthorized = new ServerResponse { RespCode = 401 };
        public static ServerResponse Forbidden = new ServerResponse { RespCode = 403 };
        public static ServerResponse NotFound = new ServerResponse { RespCode = 404 };

        public int RespCode { get; set; }
        public string RespDesc { get; set; }
        public IList<ValidationFailure> ErrorDesc { get; set; }
    }
}
