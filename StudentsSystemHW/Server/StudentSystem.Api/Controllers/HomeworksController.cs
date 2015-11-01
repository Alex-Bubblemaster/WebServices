namespace StudentSystem.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models;
    using StudentSystem.Models;    

    public class HomeworksController : ApiController
    {
        private readonly IRepository<Homework> homeworks;
        private readonly IRepository<Course> courses;

        public HomeworksController()
        {
            var dbContext = new StudentSystemDbContext();
            this.courses = new EfRepository<Course>(dbContext);
            this.homeworks = new EfRepository<Homework>(dbContext);
        }

        public IHttpActionResult Get()
        {
            var result = this.homeworks
                .All()
                .ProjectTo<HomeworkRequestModel>()
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var homeworkFromDb = this.homeworks
                .GetById(id);

            if (homeworkFromDb == null)
            {
                return this.NotFound();
            }

            var result = Mapper.Map<HomeworkRequestModel>(homeworkFromDb);
            return this.Ok(result);
        }

        public IHttpActionResult Post(HomeworkRequestModel model)
        {
            var courseInDb = this.courses.GetById(model.CourseId);
            if (courseInDb == null)
            {
                return this.NotFound();
            }

            var homeworkToAdd = new Homework
            {
                CourseId = model.CourseId,
                StudentIdentification = model.StudentIdentification,
                FileUrl = model.FileUrl,
                TimeSent = DateTime.Now
            };

            this.homeworks.Add(homeworkToAdd);
            return this.Ok("Homework added successfully!");
        }

        [HttpPut]
        public IHttpActionResult Update(HomeworkRequestModel model)
        {
            var courseInDb = this.courses.GetById(model.CourseId);
            if (courseInDb == null)
            {
                return this.NotFound();
            }

            var homeworkToUpdate = new Homework
            {
                Id = model.Id,
                CourseId = model.CourseId,
                StudentIdentification = model.StudentIdentification,
                FileUrl = model.FileUrl,
                TimeSent = DateTime.Now
            };

            this.homeworks.Update(homeworkToUpdate);
            this.homeworks.SaveChanges();
            return this.Ok("Homework updated successfully!");
        }
    }
}