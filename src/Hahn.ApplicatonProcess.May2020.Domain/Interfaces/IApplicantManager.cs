using Hahn.ApplicatonProcess.May2020.Domain.Models;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Domain.Interfaces
{
    public interface IApplicantManager
    {
        Task<ApplicantModel> GetApplicantAsync(int Id);
        Task<ServerResponse> CreateApplicantAsync(ApplicantModel model);
        Task<ServerResponse> UpdateApplicantAsync(int id, ApplicantModel model);
        Task<ServerResponse> DeleteApplicantAsync(int id);
    }
}
