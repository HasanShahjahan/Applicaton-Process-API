using System.Threading.Tasks;
using Hahn.ApplicatonProcess.May2020.Domain.Interfaces;
using Hahn.ApplicatonProcess.May2020.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hahn.ApplicatonProcess.May2020.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantManager _applicantManager;
        public ApplicantController(IApplicantManager applicantManager)
        {
            _applicantManager = applicantManager;
        }

        
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _applicantManager.GetApplicantAsync(id);
            return Ok(result);
        }

        
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> Post([FromBody] ApplicantModel request)
        {
            var result = await _applicantManager.CreateApplicantAsync(request);
            return Ok(result);
        }

        
        [HttpPut("{id}")]
        [Consumes("application/json")]
        public async Task<IActionResult> Put(int id, [FromBody] ApplicantModel request)
        {
            var result = await _applicantManager.UpdateApplicantAsync(id, request);
            return Ok(result);
        }

        
        [HttpDelete("{id}")]
        [Consumes("application/json")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _applicantManager.DeleteApplicantAsync(id);
            return Ok(result);
        }
    }
}
