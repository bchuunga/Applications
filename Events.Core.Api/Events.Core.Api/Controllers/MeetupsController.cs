using AutoMapper;
using Events.Core.Api.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Events.Core.Api.Models;

namespace Events.Core.Api.Controllers
{
    [Route("api/meetups")]
    [ApiController]
    public class MeetupsController : ControllerBase
    {
        private readonly MeetupContext _context;
        private readonly IMapper _mapper;

        public MeetupsController(MeetupContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<MeetupDto>> GetAll()
        {
            var meetup = await _context.Meetups.ToListAsync();
            return _mapper.Map<IEnumerable<MeetupDto>>(meetup);
        }

        [HttpGet("meetup/{id}")]
        public async Task<MeetupDto> Get(int id)
        {
            var meetup = await _context.Meetups.FindAsync(id);

            if (meetup == null)
            {
                throw new Exception("Meetup not found");
            }

            return _mapper.Map<MeetupDto>(meetup);
        }

        [HttpGet("user/{userId}")]
        public async Task<IEnumerable<MeetupDto>> GetByUser(Guid userId)
        {
            var meetups = await _context.Meetups
                .Where(x => x.CreatedBy == userId)
                .ToListAsync();

            List<MeetupDto> meetupDtos = _mapper.Map<List<MeetupDto>>(meetups);

            return meetupDtos;
        }

        [HttpPut("update")]
        public async Task<MeetupDto> Update(MeetupDto meetupDto)
        {
            var meetup = await _context.Meetups
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == meetupDto.Id);
            if (meetup == null)
            {
                throw new Exception("Meetup not found");
            }

            var updatedMeetup = _mapper.Map<Meetup>(meetupDto);
            _context.Update(updatedMeetup);
            await _context.SaveChangesAsync();
            return _mapper.Map<MeetupDto>(updatedMeetup);
        }

        [HttpPost("create")]
        public async Task<MeetupDto> Create(MeetupDto meetupDto)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Invalid model state");
            }

            var meetup = _mapper.Map<Meetup>(meetupDto);
            _context.Meetups.Add(meetup);
            await _context.SaveChangesAsync();
            return _mapper.Map<MeetupDto>(meetup);
        }

        [HttpDelete("delete/{id}")]
        public async Task<bool> Delete(int id)
        {
            var meetup = await _context.Meetups.FindAsync(id);
            if (meetup == null)
            {
                throw new Exception("Meetup not found");
            }

            _context.Meetups.Remove(meetup);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
