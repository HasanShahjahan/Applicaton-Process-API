using Hahn.ApplicatonProcess.May2020.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Domain.Interfaces
{
    public interface IApplicantManager
    {
        Task<ApplicantModel> GetApplicantAsync(int Id);
        Task<ApplicantModel> CreateApplicantAsync(ApplicantModel model);
        Task<ApplicantModel> UpdateApplicantAsync(int id, ApplicantModel model);
        Task<ApplicantModel> DeleteApplicantAsync(int id);
    }
}
