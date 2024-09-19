using Events.Core.Web.Dtos;

namespace Events.Core.Web.Services.Interfaces
{
    public interface ILectureService
    {
        Task<IEnumerable<LectureDto>> GetAll();
        Task<IEnumerable<LectureDto>> GetByMeetup(int meetupId);
        Task<LectureDto> GetById(int id);
        Task<LectureDto> Update(LectureDto lectureDto);
        Task<LectureDto> PostLecture(LectureDto lectureDto);
        Task<bool> Delete(int id);
    }
}
