using AutoMapper;
using Events.Core.Api.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Events.Core.Api.Models;

namespace Events.Core.Api.Controllers
{
    [Route("api/lectures")]
    [ApiController]
    public class LecturesController : ControllerBase
    {
        private readonly MeetupContext _context;
        private readonly IMapper _mapper;

        public LecturesController(MeetupContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<LectureDto>> GetAll()
        {
            var lectures = await _context.Lectures.ToListAsync();
            return _mapper.Map<List<LectureDto>>(lectures);
        }

        [HttpGet("meetup/{meetupId}")]
        public async Task<IEnumerable<LectureDto>> GetByMeetup(int meetupId)
        {
            var lectures = await _context.Lectures.Where(x => x.MeetupId == meetupId).ToListAsync();
            return _mapper.Map<List<LectureDto>>(lectures);
        }

        [HttpGet("lecture/{id}")]
        public async Task<LectureDto> GetById(int id)
        {
            var lecture = await _context.Lectures.FindAsync(id);

            if (lecture == null)
            {
                throw new Exception("Lecture not found");
            }

            return _mapper.Map<LectureDto>(lecture);
        }
        
        [HttpPut("update")]
        public async Task<LectureDto> Update(LectureDto lectureDto)
        {
            var lecture = await _context.Lectures
                .AsNoTracking()
                .FirstOrDefaultAsync(l => l.Id == lectureDto.Id);
            if (lecture == null)
            {
                throw new Exception("Lecture not found");
            }
            
            var updatedLecture = _mapper.Map<Lecture>(lectureDto);
            _context.Update(updatedLecture);
            await _context.SaveChangesAsync();
            return lectureDto;
        }
        
        [HttpPost("create")]
        public async Task<LectureDto> PostLecture(LectureDto lectureDto)
        {
            if(!ModelState.IsValid)
            {
                throw new Exception("Invalid model state");
            }
            
            var lecture = _mapper.Map<Lecture>(lectureDto);
            _context.Lectures.Add(lecture);
            await _context.SaveChangesAsync();

            return lectureDto;
        }

        [HttpDelete("delete/{meetupId}")]
        public async Task<bool> Delete(int id)
        {
            var lecture = await _context.Lectures.FindAsync(id);
            if (lecture == null)
            {
                throw new Exception("Lecture not found");
            }

            _context.Lectures.Remove(lecture);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
