namespace Events.Core.Web.Constatnts.ApiClient
{
    public static class EventsCoreMeetupEndpoints
    {
        public static string GetAll = "api/meetups/all";
        public static string GetById = "api/meetups/meetup/{id}";
        public static string GetByUser = "api/meetups/user/{userId}";
        public static string Update = "api/meetups/update";
        public static string Create = "api/meetups/create";
        public static string Delete = "api/meetups/delete/{id}";
    }
}
