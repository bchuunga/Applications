namespace Events.Core.Api.Dtos
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public int MeetupId { get; set; }
    }
}
