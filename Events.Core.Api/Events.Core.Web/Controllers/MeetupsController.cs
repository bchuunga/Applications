using Events.Core.Web.Dtos;
using Events.Core.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Events.Core.Web.Controllers
{
    [Route("api/meetups")]
    [ApiController]
    [Authorize]
    public class MeetupsController : ControllerBase
    {
        private readonly IMeetupService _meetupService;

        public MeetupsController(IMeetupService meetupService)
        {
            _meetupService = meetupService;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<MeetupDto>> GetAll()
        {
            var meetups = await _meetupService.GetAll();
            return meetups;
        }

        [HttpGet("meetup/{id}")]
        public async Task<MeetupDto> Get(int id)
        {
            var meetups = await _meetupService.GetById(id);
            return meetups;
        }

        [HttpGet("user/{userId}")]
        public async Task<IEnumerable<MeetupDto>> GetById(Guid userId)
        {
            var meetups = await _meetupService.GetByUser(userId);
            return meetups;
        }
    }
}
