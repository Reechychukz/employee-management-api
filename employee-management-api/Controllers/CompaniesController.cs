using Contracts;
using Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace employee_management_api.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public CompaniesController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetCompanies()
        {
            try
            {
                var companies = _repository.Company.GetAllCompanies(trackChanges: false);
                return Ok(companies);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetCompanies)}action { ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
