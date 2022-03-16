using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class CompanyMapper : Profile
    {
        public CompanyMapper()
        {
            AllowNullCollections = true;
            CreateMap<Company, CompanyDto>()
                .ReverseMap();
            CreateMap<Employee, EmployeeDTO>();

            CreateMap<CreateCompanyDTO, Company>();
        }
    }
}
