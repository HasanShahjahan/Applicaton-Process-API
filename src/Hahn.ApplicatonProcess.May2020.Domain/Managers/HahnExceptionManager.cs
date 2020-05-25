using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.May2020.Domain.Managers
{
    public class HahnExceptionManager : Exception
    {
        public HahnExceptionManager(int errorCode, string message, string field = null) : base(message)
        {
            ErrorCode = errorCode;
            Field = field;
        }

        public int ErrorCode { get; set; }
        public string Field { get; set; }
    }
}
