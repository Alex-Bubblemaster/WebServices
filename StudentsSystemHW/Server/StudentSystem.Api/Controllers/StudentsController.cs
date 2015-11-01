namespace StudentSystem.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models;
    using StudentSystem.Models;

    public class StudentsController : ApiController
    {
        private readonly IRepository<Student> students;
        
        public StudentsController()
        {
            this.students = new EfRepository<Student>(new StudentSystemDbContext());
        } 

        public IHttpActionResult Get()
        {
            var result = this.students
                .All()
                .ProjectTo<StudentRequestModel>()
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Post(StudentRequestModel model)
        {
            var studentToAdd = new Student
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Level = model.Level,
                StudentIdentification = model.StudentIdentification,
                AdditionalInformation = model.AdditionalInformation,
                Courses = model.Courses
            };

            this.students.Add(studentToAdd);
            return this.Ok(string.Format("Student {0} successfully added!", studentToAdd.FirstName));
        }
    }
}