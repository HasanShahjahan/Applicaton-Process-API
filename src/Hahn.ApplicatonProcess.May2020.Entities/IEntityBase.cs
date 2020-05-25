using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.May2020.Entities
{
    public interface IEntityBase
    {
        int ID { get; set; }

        DateTime CreatedDate { get; set; }

        DateTime? UpdatedDate { get; set; }
    }
}
