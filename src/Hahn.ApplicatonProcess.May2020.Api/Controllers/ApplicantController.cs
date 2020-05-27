using System.Threading.Tasks;
using Hahn.ApplicatonProcess.May2020.Domain.Interfaces;
using Hahn.ApplicatonProcess.May2020.Domain.Models;
using Hahn.ApplicatonProcess.May2020.Domain.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Hahn.ApplicatonProcess.May2020.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantManager _applicantManager;
        private readonly IValidationManager _validationManager;
        private readonly IErrorMapper _errorMapper;
        public ApplicantController(IApplicantManager applicantManager, IValidationManager validationManager, IErrorMapper errorMapper)
        {
            _applicantManager = applicantManager;
            _validationManager = validationManager;
            _errorMapper = errorMapper;
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
            var validationResult = _validationManager.Validate(new ApplicantModelValidator(), request);
            if (validationResult.Errors.Count > 0)
                return Ok(_errorMapper.MapToError(ServerResponse.BadRequest, validationResult.Errors));
            var response = await _applicantManager.CreateApplicantAsync(request);
            return Ok(response);
        }

        
        [HttpPut("{id}")]
        [Consumes("application/json")]
        public async Task<IActionResult> Put(int id, [FromBody] ApplicantModel request)
        {
            var validationResult = _validationManager.Validate(new ApplicantModelValidator(), request);
            if (validationResult.Errors.Count > 0)
                return Ok(_errorMapper.MapToError(ServerResponse.BadRequest, validationResult.Errors));
            var response = await _applicantManager.UpdateApplicantAsync(id, request);
            return Ok(response);
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
