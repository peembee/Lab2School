using Lab2School.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab2School.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
            
        }
        public DbSet<Class> Classes { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseList> CoursesLists { get; set;}

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Lab2School.Models.StudentTeacher> StudentTeacher { get; set; } = default!;
        public DbSet<Lab2School.Models.StudentTeacherCourse> StudentTeacherCourse { get; set; } = default!;
   

    }
}
