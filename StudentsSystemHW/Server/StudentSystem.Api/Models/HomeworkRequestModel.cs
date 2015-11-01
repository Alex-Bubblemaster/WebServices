namespace StudentSystem.Api.Models
{
    using System;
    using StudentSystem.Models;

    public class HomeworkRequestModel
    {
        public int Id { get; set; }

        public string FileUrl { get; set; }

        public DateTime TimeSent { get; set; }

        public int StudentIdentification { get; set; }

        public int CourseId { get; set; }
    }
}