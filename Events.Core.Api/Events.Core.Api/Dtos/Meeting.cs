namespace Events.Core.Api.Dtos
{
    public class Meeting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Organizer { get; set; }
        public DateTime Date { get; set; }
        public bool IsPrivate { get; set; }
        public Guid CreatedBy { get; set; }

        public LocationDto Location { get; set; }
        public List<LectureDto> Lectures { get; set; }
    }
}
