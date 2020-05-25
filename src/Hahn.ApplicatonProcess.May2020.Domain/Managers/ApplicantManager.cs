using Hahn.ApplicatonProcess.May2020.Data.Repositories;
using Hahn.ApplicatonProcess.May2020.Domain.Interfaces;
using Hahn.ApplicatonProcess.May2020.Domain.Mappers;
using Hahn.ApplicatonProcess.May2020.Domain.Models;
using Hahn.ApplicatonProcess.May2020.Entities;
using System;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Domain.Managers
{
    public class ApplicantManager : IApplicantManager
    {
        private readonly ApplicantRepository _applicantRepository;

        public ApplicantManager(ApplicantRepository applicantRepository)
        {
            _applicantRepository = applicantRepository;
        }

        public async Task<ApplicantModel> CreateApplicantAsync(ApplicantModel model)
        {
            var applicant = await _applicantRepository.GetItemByIdAsync(model.ID);
            if (applicant != null) throw new HahnExceptionManager(400, "Already exists in system.");
            var applicantEntity = await _applicantRepository.AddAsync(model.ToCommand());
            return applicantEntity.ToQueries();
        }

        public async Task<ApplicantModel> UpdateApplicantAsync(int id, ApplicantModel model)
        {
            var applicant = await _applicantRepository.GetItemByIdAsync(id);
            if (applicant == null) throw new HahnExceptionManager(400, "Doesn't exist in system.");
            
            applicant.Name = model.Name;
            applicant.FamilyName = model.FamilyName;
            applicant.Address = model.Address;
            applicant.Age = model.Age;
            applicant.CountryOfOrigin = model.CountryOfOrigin;
            applicant.CreatedDate = model.CreatedDate;
            applicant.UpdatedDate = DateTime.Now;
            applicant.Hired = model.Hired;
            applicant.EMailAdress = model.EMailAdress;

            var applicantEntity = await _applicantRepository.UpdateAsync(applicant);
            return applicantEntity.ToQueries();
        }

        public async Task<ApplicantModel> DeleteApplicantAsync(int id)
        {
            var applicant = await _applicantRepository.GetItemByIdAsync(id);
            if (applicant == null) throw new HahnExceptionManager(401, "Doesn't exist in system.");
            var applicantEntity = await _applicantRepository.RemoveAsync(applicant);
            return applicantEntity.ToQueries();
        }

        public async Task<ApplicantModel> GetApplicantAsync(int Id)
        {
            var applicant = await _applicantRepository.GetItemByIdAsync(Id);
            if (applicant == null) throw new HahnExceptionManager(401, "Doesn't exist in system.");
            var applicantEntity = await _applicantRepository.GetItemByIdAsync(Id);
            return applicantEntity.ToQueries();
        }

       
    }
}
