using Hahn.ApplicatonProcess.May2020.Data.Repositories;
using Hahn.ApplicatonProcess.May2020.Domain.Interfaces;
using Hahn.ApplicatonProcess.May2020.Domain.Mappers;
using Hahn.ApplicatonProcess.May2020.Domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Domain.Managers
{
    public class ApplicantManager : IApplicantManager
    {
        private readonly ApplicantRepository _applicantRepository;
        private readonly IErrorMapper _errorMapper;
        private readonly ILogger<ApplicantManager> _logger;

        public ApplicantManager(ApplicantRepository applicantRepository, IErrorMapper errorMapper, ILogger<ApplicantManager> logger)
        {
            _applicantRepository = applicantRepository;
            _errorMapper = errorMapper;
            _logger = logger;
        }

        public async Task<ServerResponse> CreateApplicantAsync(ApplicantModel model)
        {
            var response = ServerResponse.OK;
            _logger.LogInformation("Get Item by ID: " + model.ID);
            var applicant = await _applicantRepository.GetItemByIdAsync(model.ID);
            if (applicant != null)
            {
                _logger.LogInformation("Already exists in system.");
                return _errorMapper.MapToError(ServerResponse.BadRequest, "Already exists in system.");
            }
                
            await _applicantRepository.AddAsync(model.ToCommand());
            _logger.LogInformation("Applicant is added by applicant repository.");
            return response;
        }

        public async Task<ServerResponse> UpdateApplicantAsync(int id, ApplicantModel model)
        {
            var response = ServerResponse.OK;
            _logger.LogInformation("Get Item by ID: " + model.ID);
            var applicant = await _applicantRepository.GetItemByIdAsync(id);
            if (applicant == null)
            {
                _logger.LogInformation("Applicant doesn't exist in system.");
                return _errorMapper.MapToError(ServerResponse.BadRequest, "Applicant doesn't exist in system.");
            }
                
            
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
            _logger.LogInformation("Applicant is updated by applicant repository.");
            return response;
        }

        public async Task<ServerResponse> DeleteApplicantAsync(int id)
        {
            var response = ServerResponse.OK;
            _logger.LogInformation("Get Item by ID: " + id);
            var applicant = await _applicantRepository.GetItemByIdAsync(id);
            if (applicant == null)
            {
                _logger.LogInformation("Applicant doesn't exist in system.");
                return _errorMapper.MapToError(ServerResponse.BadRequest, "Applicant doesn't exist in system.");
            }
            await _applicantRepository.RemoveAsync(applicant);
            _logger.LogInformation("Applicant is deleted by applicant repository.");
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
