﻿namespace Events.Core.Web.Dtos
{
    public class LectureDto
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public int MeetupId { get; set; }
    }
}
