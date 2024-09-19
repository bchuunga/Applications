using AutoMapper;
using Events.Core.Api.Dtos;
using Events.Core.Api.Models;

namespace Events.Core.Api.Profiles
{
    public class MeetUpCoreApiProfiles : Profile
    {
        public MeetUpCoreApiProfiles()
        {
            CreateMap<Meetup, MeetupDto>().ReverseMap();
            CreateMap<Meetup, Meeting>().ReverseMap();
            CreateMap<Location, LocationDto>().ReverseMap();
            CreateMap<Lecture, LectureDto>().ReverseMap();
        }
    }
}
