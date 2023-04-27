using AutoMapper;
using CallCenterProject.Data.DTO.InterviewDTO;
using CallCenterProject.Data.Entities;

namespace CallCenterProject.Data.Profiles
{
    public class InterviewProfile: Profile
    {
        public InterviewProfile()
        {
            CreateMap<Interview, InterviewInfo>()
                .ReverseMap();
            CreateMap<Interview, InterviewCreate>()
                .ReverseMap();
        }
    }
}
