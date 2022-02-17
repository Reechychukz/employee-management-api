using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanger);
    }
}
