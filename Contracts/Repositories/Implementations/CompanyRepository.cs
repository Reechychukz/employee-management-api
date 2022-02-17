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
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }

        public void CreateCompany(Company company) => Create(company);

        public IEnumerable<Company> GetAllCompanies(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToList();

        public Company GetCompany(Guid id, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(id), trackChanges)
            .SingleOrDefault();
    }
}
