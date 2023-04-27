using AutoMapper;
using CallCenterProject.Data.DTO.RepresentativeDTO;
using CallCenterProject.Data.Entities;

namespace CallCenterProject.Data.Profiles
{
    public class RepresentativeProfile: Profile
    {
        public RepresentativeProfile() {
            CreateMap<Representative, RepresentativeLogin>()
                .ReverseMap();
            CreateMap<Representative, RepresntativeSignIn>()
                .ReverseMap();
            CreateMap<Representative, RepresentativeInfo>()
                .ReverseMap();
        }
    }
}
