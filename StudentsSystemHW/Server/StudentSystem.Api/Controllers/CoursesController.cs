namespace StudentSystem.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models;
    using StudentSystem.Models;

    public class CoursesController : ApiController
    {
        private readonly IRepository<Course> courses;

        public CoursesController()
        {
            this.courses = new EfRepository<Course>(new StudentSystemDbContext());
        }

        public IHttpActionResult Get()
        {
            Mapper.CreateMap<Course, CourseRequestModel>();

            var result = this.courses
                .All()
                .ProjectTo<CourseRequestModel>()
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var resultFromDb = this.courses
                .GetById(id);

            var result = Mapper.Map<CourseRequestModel>(resultFromDb);

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        public IHttpActionResult Post(CourseRequestModel model)
        {
            // TODO get Automapper to work here
            var dbModel = new Course
            {
                Id = model.Id,
                Description = model.Description,
                Name = model.Name
            };

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            this.courses.Add(dbModel);

            return this.Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(CourseRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            // TODO get Automapper to work here
            var courseToBeUpdated = new Course
            {
                Id = model.Id,
                Description = model.Description,
                Name = model.Name
            };
            this.courses.Update(courseToBeUpdated);
            this.courses.SaveChanges();

            return this.Ok();
        }

        public IHttpActionResult Delete(CourseRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var courseToBeDeleted = new Course
            {
                Id = model.Id,
                Description = model.Description,
                Name = model.Name
            };
            this.courses.Delete(courseToBeDeleted);
            this.courses.SaveChanges();

            return this.Ok("Course has been deleted");
        }
    }
}