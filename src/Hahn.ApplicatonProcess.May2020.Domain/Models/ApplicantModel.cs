using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.May2020.Domain.Models
{
    public class ApplicantModel : EntityBase
    {
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("familyName")] public string FamilyName { get; set; }
        [JsonProperty("address")] public string Address { get; set; }
        [JsonProperty("countryOfOrigin")] public string CountryOfOrigin { get; set; }
        [JsonProperty("emailAdress")]  public string EMailAdress { get; set; }
        [JsonProperty("age")] public int Age { get; set; }
        [JsonProperty("hired")] public bool Hired { get; set; }
    }
}
