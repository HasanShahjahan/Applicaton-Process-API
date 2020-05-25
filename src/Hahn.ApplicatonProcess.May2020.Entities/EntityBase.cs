using System;

namespace Hahn.ApplicatonProcess.May2020.Entities
{
    public abstract class EntityBase : IEntityBase
    {
        public int ID { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedDate { get; set; }
    }
}
