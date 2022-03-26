using Application.DTOs;
using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace Application.Mapper
{
    public class CompanyMapper : Profile
    {
        public CompanyMapper()
        {
            AllowNullCollections = true;
            CreateMap<Company, CompanyDto>()
                .ForMember(c => c.FullAddress, opt => 
                 opt.MapFrom(x => string.Join(' ', x.Address, x.Country)))
                .ReverseMap();
            CreateMap<Employee, EmployeeDTO>();

            CreateMap<CompanyForCreationDto, Company>();
            CreateMap<EmployeeForCreationDto, Employee>();
        }
    }
}
