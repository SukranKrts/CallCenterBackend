using AutoMapper;
using CallCenterProject.Data.DTO.RequestDTO;
using CallCenterProject.Data.Entities;

namespace CallCenterProject.Data.Profiles
{
    public class RequestProfile: Profile
    {
        public RequestProfile() {
            CreateMap<RequestEntity, RequestInfo>()
                .ReverseMap();
            CreateMap<RequestEntity, CreateRequest>()
                .ReverseMap();
        }
    }
}
