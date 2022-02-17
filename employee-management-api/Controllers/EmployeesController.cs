﻿using Application.DTOs;
using AutoMapper;
using Contracts;
using Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace employee_management_api.Controllers
{
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public EmployeesController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCompanyEmployees(Guid companyId)
        {
            var company = _repository.Company.GetCompany(companyId, trackChanges: false);
            if(company == null)
            {
                _logger.LogInfo($"Company with id: {companyId} doesn't exist in the database.");
                return NotFound();
            }

            var employeesFromDb = _repository.Employee.GetEmployees(companyId, trackChanger: false);
            var employesDto = _mapper.Map<IEnumerable<EmployeeDTO>>(employeesFromDb);
            return Ok(employeesFromDb);
        }
    }
}