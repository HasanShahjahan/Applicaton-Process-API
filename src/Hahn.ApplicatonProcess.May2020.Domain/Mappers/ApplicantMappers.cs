using Hahn.ApplicatonProcess.May2020.Domain.Models;
using Hahn.ApplicatonProcess.May2020.Entities;

namespace Hahn.ApplicatonProcess.May2020.Domain.Mappers
{
    public static class ApplicantMappers
    {
        public static Applicant ToCommand(this ApplicantModel model)
        {
            return new Applicant
            {
                ID = model.ID,
                Name = model.Name,
                Address = model.Address,
                Age = model.Age,
                CountryOfOrigin = model.CountryOfOrigin,
                CreatedDate = model.CreatedDate,
                EMailAdress = model.EMailAdress,
                FamilyName = model.FamilyName,
                Hired = model.Hired,
                UpdatedDate = model.UpdatedDate
            };
        }
        public static ApplicantModel ToCommand(this Applicant model)
        {
            return new ApplicantModel
            {
                ID = model.ID,
                Name = model.Name,
                Address = model.Address,
                Age = model.Age,
                CountryOfOrigin = model.CountryOfOrigin,
                CreatedDate = model.CreatedDate,
                EMailAdress = model.EMailAdress,
                FamilyName = model.FamilyName,
                Hired = model.Hired,
                UpdatedDate = model.UpdatedDate
            };
        }
        public static ApplicantModel ToQueries(this Applicant model)
        {
            return new ApplicantModel
            {
                ID = model.ID,
                Name = model.Name,
                Address = model.Address,
                Age = model.Age,
                CountryOfOrigin = model.CountryOfOrigin,
                CreatedDate = model.CreatedDate,
                EMailAdress = model.EMailAdress,
                FamilyName = model.FamilyName,
                Hired = model.Hired,
                UpdatedDate = model.UpdatedDate
            };
        }
    }
}
