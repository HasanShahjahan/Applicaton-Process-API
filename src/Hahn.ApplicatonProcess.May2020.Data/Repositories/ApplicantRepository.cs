using Hahn.ApplicatonProcess.May2020.Data.Base;
using Hahn.ApplicatonProcess.May2020.Data.DbContext;
using Hahn.ApplicatonProcess.May2020.Entities;
using System;

namespace Hahn.ApplicatonProcess.May2020.Data.Repositories
{
    public class ApplicantRepository : GenericRepository<Applicant>
    {
        public ApplicantRepository(HahnDbContext context) : base(context)
        {
        }
    }
}