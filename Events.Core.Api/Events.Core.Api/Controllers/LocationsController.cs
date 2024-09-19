using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Events.Core.Api.Models;
using AutoMapper;
using Events.Core.Api.Dtos;

namespace Events.Core.Api.Controllers
{
    [Route("api/locations")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly MeetupContext _context;
        private readonly IMapper _mapper;

        public LocationsController(MeetupContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<LocationDto>> GetAll()
        {
            var locations = await _context.Locations.ToListAsync();
            return _mapper.Map<List<LocationDto>>(locations);
        }

        [HttpGet("meetup/{meetupId}")]
        public async Task<IEnumerable<LocationDto>> GetByMeetup(int meetupId)
        {
            var locations = await _context.Locations.Where(x => x.MeetupId == meetupId).ToListAsync();
            return _mapper.Map<List<LocationDto>>(locations);
        }

        [HttpGet("location/{id}")]
        public async Task<LocationDto> GetById(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                throw new Exception("Location not found");
            }

            return _mapper.Map<LocationDto>(location);
        }

        [HttpPut("update")]
        public async Task<LocationDto> Update(LocationDto locationDto)
        {
            var location = await _context
                .Locations
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == locationDto.Id);
            if (location == null)
            {
                throw new Exception("Location not found");
            }

            var updatedLocation = _mapper.Map<Location>(locationDto);
            _context.Entry(updatedLocation).State = EntityState.Detached;
            await _context.SaveChangesAsync();
            return locationDto;
        }

        [HttpPost("create")]
        public async Task<LocationDto> Create(LocationDto locationDto)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Invalid model state");
            }

            var location = _mapper.Map<Location>(locationDto);
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return locationDto;
        }

        [HttpDelete("delete/{id}")]
        public async Task<bool> Delete(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                throw new Exception("Location not found");
            }

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
