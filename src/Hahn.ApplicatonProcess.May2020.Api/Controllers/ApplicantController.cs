using System.Threading.Tasks;
using Hahn.ApplicatonProcess.May2020.Domain.Interfaces;
using Hahn.ApplicatonProcess.May2020.Domain.Models;
using Hahn.ApplicatonProcess.May2020.Domain.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Hahn.ApplicatonProcess.May2020.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantManager _applicantManager;
        private readonly IValidationManager _validationManager;
        private readonly IErrorMapper _errorMapper;
        private readonly ILogger<ApplicantController> _logger;
        public ApplicantController(IApplicantManager applicantManager, IValidationManager validationManager, IErrorMapper errorMapper, ILogger<ApplicantController> logger)
        {
            _applicantManager = applicantManager;
            _validationManager = validationManager;
            _errorMapper = errorMapper;
            _logger = logger;
        }

        /// <summary>
        /// Get an Applicant By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A Applicant get </returns>
        /// <response code="201">Returns item</response>
        /// <response code="400">If the item is null</response>   
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            _logger.LogInformation("Start Get Applicant Information for ID: " + id + ".");
            var result = await _applicantManager.GetApplicantAsync(id);
            _logger.LogInformation("End Get Applicant Information for ID: " + JsonConvert.SerializeObject(result));
            return Ok(result);
        }

        /// <summary>
        /// Create an Applicant
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///        "id": 1,
        ///        "name": "Md Shahjahan Miah",
        ///        "familyName": "Miahhhhh",
        ///        "address": "Bangkok,Thailand",
        ///        "countryOfOrigin": "Bangladesh",
        ///        "emailAdress": "blackbee08@gmail.com",
        ///        "age": 33,
        ///        "hired": true
        ///     }
        ///
        /// </remarks>
        /// <param name="request"></param>
        /// <returns>A newly created Applicant</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>         
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes("application/json")]
        public async Task<IActionResult> Post([FromBody] ApplicantModel request)
        {
            _logger.LogInformation("POST for creating Applicant with request: " + JsonConvert.SerializeObject(request));
            var validationResult = _validationManager.Validate(new ApplicantModelValidator(), request);
            if (validationResult.Errors.Count > 0)
                return Ok(_errorMapper.MapToError(ServerResponse.BadRequest, validationResult.Errors));
            var response = await _applicantManager.CreateApplicantAsync(request);
            _logger.LogInformation("POST for creating Applicant with response: " + JsonConvert.SerializeObject(response));
            return Ok(response);

        }

        /// <summary>
        /// Update an Applicant
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///        "id": 1,
        ///        "name": "Miah Md Shahjahan ",
        ///        "familyName": "Miahhhhh",
        ///        "address": "Bangkok,Thailand",
        ///        "countryOfOrigin": "Bangladesh",
        ///        "emailAdress": "blackbee08@gmail.com",
        ///        "age": 43,
        ///        "hired": true
        ///     }
        ///
        /// </remarks>
        /// <param name="request"></param>
        /// <returns>A update Applicant</returns>
        /// <response code="201">Returns updated item</response>
        /// <response code="400">If the item is null</response>   
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes("application/json")]
        public async Task<IActionResult> Put(int id, [FromBody] ApplicantModel request)
        {
            _logger.LogInformation("PUT for updating Applicant with request: " + JsonConvert.SerializeObject(request));
            var validationResult = _validationManager.Validate(new ApplicantModelValidator(), request);
            if (validationResult.Errors.Count > 0)
                return Ok(_errorMapper.MapToError(ServerResponse.BadRequest, validationResult.Errors));
            var response = await _applicantManager.UpdateApplicantAsync(id, request);
            _logger.LogInformation("PUT for updating Applicant with response: " + JsonConvert.SerializeObject(response));
            return Ok(response);
        }

        /// <summary>
        /// Delete an Applicant
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Delete  Applicant status </returns>
        /// <response code="201">Returns deleted status item</response>
        /// <response code="400">If the item is null</response>   
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes("application/json")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation("Start deleting Applicant with ID: " + id);
            var result = await _applicantManager.DeleteApplicantAsync(id);
            _logger.LogInformation("End deletation Applicant with ID: " + id);
            return Ok(result);
        }
    }
}
