using Hahn.ApplicatonProcess.May2020.Data.Repositories;
using Hahn.ApplicatonProcess.May2020.Domain.Interfaces;
using Hahn.ApplicatonProcess.May2020.Domain.Mappers;
using Hahn.ApplicatonProcess.May2020.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Domain.Managers
{
    public class ApplicantManager : IApplicantManager
    {
        private readonly ApplicantRepository _applicantRepository;
        private readonly IErrorMapper _errorMapper;

        public ApplicantManager(ApplicantRepository applicantRepository, IErrorMapper errorMapper)
        {
            _applicantRepository = applicantRepository;
            _errorMapper = errorMapper;
        }

        public async Task<ServerResponse> CreateApplicantAsync(ApplicantModel model)
        {
            var response = ServerResponse.OK;
            var applicant = await _applicantRepository.GetItemByIdAsync(model.ID);
            if (applicant != null)
                return _errorMapper.MapToError(ServerResponse.BadRequest, "Already exists in system.");
            await _applicantRepository.AddAsync(model.ToCommand());
            return response;
        }

        public async Task<ServerResponse> UpdateApplicantAsync(int id, ApplicantModel model)
        {
            var response = ServerResponse.OK;
            var applicant = await _applicantRepository.GetItemByIdAsync(id);
            if (applicant == null) 
                return _errorMapper.MapToError(ServerResponse.BadRequest, "Applicant doesn't exist in system.");
            
            applicant.Name = model.Name;
            applicant.FamilyName = model.FamilyName;
            applicant.Address = model.Address;
            applicant.Age = model.Age;
            applicant.CountryOfOrigin = model.CountryOfOrigin;
            applicant.CreatedDate = model.CreatedDate;
            applicant.UpdatedDate = DateTime.Now;
            applicant.Hired = model.Hired;
            applicant.EMailAdress = model.EMailAdress;

            await _applicantRepository.UpdateAsync(applicant);
            return response;
        }

        public async Task<ServerResponse> DeleteApplicantAsync(int id)
        {
            var response = ServerResponse.OK;
            var applicant = await _applicantRepository.GetItemByIdAsync(id);
            if (applicant == null)
                return _errorMapper.MapToError(ServerResponse.BadRequest, "Applicant doesn't exist in system.");
            await _applicantRepository.RemoveAsync(applicant);
            return response;
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
