namespace Events.Core.Web.Constatnts.ApiClient
{
    public static class EventsCoreLectureEndpoints
    {
        public static string GetAll = "api/lectures/all";
        public static string GetByMeetup = "api/lectures/meetup/{meetupId}";
        public static string GetById = "api/lectures/lecture/{id}";
        public static string Update = "api/lectures/update";
        public static string Create = "api/lectures/create";
        public static string Delete = "api/lectures/delete/{id}";
    }
}
