using Events.Core.Web.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Events.Core.Web.Services.Interfaces
{
    public interface IMeetupService
    {
        Task<IEnumerable<MeetupDto>> GetAll();
        Task<MeetupDto> GetById(int id);
        Task<IEnumerable<MeetupDto>> GetByUser(Guid userId);
        Task<MeetupDto> Update(MeetupDto meetupDto);
        Task<MeetupDto> Create(MeetupDto meetupDto);
        Task<bool> Delete(int id);
    }
}
