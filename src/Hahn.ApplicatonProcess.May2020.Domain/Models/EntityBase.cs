using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.May2020.Domain.Models
{
    public abstract class EntityBase
    {
        [JsonProperty("id")]  public int ID { get; set; }

        [JsonProperty("createdDate")]  public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [JsonProperty("updatedDate")]  public DateTime? UpdatedDate { get; set; }
        [JsonProperty("respCode")]  public int RespCode { get; set; }
        [JsonProperty("respDesc")]  public string RespDesc { get; set; }
    }
}
