using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2School.Models
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherID { get; set; }

        [Required]
        [StringLength(50)]
        public string TeacherFirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string TeacherLastName { get; set; }

        [Required]
        [StringLength(50)]
        public string TeacherEmail { get; set; }

        public virtual ICollection<CourseList> CourseLists { get; set;}
    }
}
