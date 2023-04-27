using AutoMapper;
using CallCenterProject.Data.DTO.CustomerDTO;
using CallCenterProject.Data.Entities;

namespace CallCenterProject.Data.Profiles
{
    public class CustomerProfile: Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerLogin>()
                .ReverseMap();
            CreateMap<Customer, CustomerSignIn>()
                .ReverseMap();
            CreateMap<Customer, CustomerInfo>()
                .ReverseMap();
            CreateMap<Customer, CustomerResponse>()
                .ReverseMap() ; 
        }
    }
}
