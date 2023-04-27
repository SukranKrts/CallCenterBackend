using AutoMapper;
using CallCenterProject.Data.DTO.UserDTO;
using CallCenterProject.Data.Entities;

namespace CallCenterProject.Data.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() {
            CreateMap<User, UserLogin>()
                .ReverseMap();
            CreateMap<User, UserInfo>()
                .ReverseMap();
        }
    }
}
