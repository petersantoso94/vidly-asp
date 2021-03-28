using AutoMapper;
using vidly.Dtos;
using vidly.Models;

namespace vidly.MappingProfile
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<MembershipType, MembershipTypeDto>();
        }
    }
}