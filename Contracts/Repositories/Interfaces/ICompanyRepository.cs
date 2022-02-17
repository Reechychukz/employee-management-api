using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Infrastructure.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAllCompanies(bool trackChanges);
        Company GetCompany(Guid id, bool trackChanges);
        void CreateCompany(Company company);
    }
}
