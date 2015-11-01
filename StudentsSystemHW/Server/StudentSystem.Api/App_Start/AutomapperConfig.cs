namespace StudentSystem.Api
{
    using AutoMapper;
    using Models;
    using StudentSystem.Models;

    public class AutomapperConfig
    {
       public static void Initialize()
        {
            Mapper.CreateMap<Course, CourseRequestModel>();
            Mapper.CreateMap<Homework, HomeworkRequestModel>();
            Mapper.CreateMap<Student, StudentRequestModel>();
        }
    }
}