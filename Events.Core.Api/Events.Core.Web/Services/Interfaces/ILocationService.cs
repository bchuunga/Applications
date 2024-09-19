using Events.Core.Web.Dtos;

namespace Events.Core.Web.Services.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<LocationDto>> GetAll();
        Task<IEnumerable<LocationDto>> GetByMeetup(int meetupId);
        Task<LocationDto> GetById(int id);
        Task<LocationDto> Update(LocationDto locationDto);
        Task<LocationDto> Create(LocationDto locationDto);
        Task<bool> Delete(int id);
    }
}
