using Domain.Entities;
using Infrastructure.Data.DbContexts;
using Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Implementations
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }

        public IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges) => 
            FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
            .OrderBy(e => e.Name);
    }
}
