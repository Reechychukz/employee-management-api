using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class CompanyMapper : Profile
    {
        public CompanyMapper()
        {
            CreateMap<Company, CompanyDto>()
                .ForMember(c => c.FullAddress,
                    opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));
        }
    }
}
