namespace Events.Core.Web.Dtos
{
    public class MeetupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Organizer { get; set; }
        public DateTime Date { get; set; }
        public bool IsPrivate { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
