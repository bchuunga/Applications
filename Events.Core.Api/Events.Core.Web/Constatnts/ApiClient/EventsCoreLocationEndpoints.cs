namespace Events.Core.Web.Constatnts.ApiClient
{
    public static class EventsCoreLocationEndpoints
    {
        public static string GetAll = "api/locations/all";
        public static string GetByMeetup = "api/locations/meetup/{meetupId}";
        public static string GetById = "api/locations/location/{id}";
        public static string Update = "api/locations/update";
        public static string Create = "api/locations/create";
        public static string Delete = "api/locations/delete/{id}";
    }
}
