namespace StudentSystem.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class StudentSystemDbContext : IdentityDbContext<User>
    {
        public StudentSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Course> Courses { get; set; }

        public virtual IDbSet<Homework>  Homeworks { get; set; }

        public virtual IDbSet<Student> Students { get; set; }

        public static StudentSystemDbContext Create()
        {
            return new StudentSystemDbContext();
        }
    }
}
