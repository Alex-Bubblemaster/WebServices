namespace StudentSystem.Api.Models
{
    using System.Collections.Generic;
    using StudentSystem.Models;

    public class StudentRequestModel
    {
        public StudentRequestModel()
        {
            this.Courses = new HashSet<Course>();
            this.Homeworks = new HashSet<Homework>();
            this.AdditionalInformation = new StudentInfo();
        }

        public int StudentIdentification { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Level { get; set; }

        public ICollection<Course> Courses { get; set; }

        public ICollection<Homework> Homeworks { get; set; }

        public StudentInfo AdditionalInformation { get; set; }
    }
}