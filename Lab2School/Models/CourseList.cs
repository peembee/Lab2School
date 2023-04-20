using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2School.Models
{
    public class CourseList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseListID { get; set; }


        [ForeignKey(name: "Teachers")]
        public int FK_TeacherID { get; set; }
        public virtual Teacher Teachers { get; set; }

        [ForeignKey(name: "Students")]
        public int FK_StudentID { get; set; }
        public virtual Student Students { get; set; }


        [ForeignKey(name: "Courses")]
        public int FK_CourseID { get; set; }
        public virtual Course Courses { get; set; }



        [ForeignKey(name: "Classes")]
        public int FK_ClassID { get; set; }
        public virtual Class Classes { get; set; }

    }
}
