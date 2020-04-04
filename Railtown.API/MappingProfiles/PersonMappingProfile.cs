using AutoMapper;
using Railtown.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Railtown.API.MappingProfiles
{
    public class PersonMappingProfile : Profile
    {
        public PersonMappingProfile()
        {
            CreateMap<Address, Models.Address>();
            CreateMap<Person, Models.Person>().ForMember(dest => dest.CompanyName, m => m.MapFrom(src => src.Company.Name));
            CreateMap<PersonsFurthestApart, Models.PersonsFurthestApart>();
        }
    }
}
