using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2School.Models
{
    public class StudentTeacherCourse
    {
        [Key]
        public int StudentTeacherCourseID { get; set; }


        public int? StudentID { get; set; }
        public string? StudentName { get; set; }


        public int? TeacherID { get; set; }
        public string? TeacherName { get; set; }
    }
}
