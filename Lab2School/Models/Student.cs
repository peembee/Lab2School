using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2School.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentID { get; set; }

        [Required]
        [StringLength(50)]
        public string StudentFirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string StudentLastName { get; set; }

        [Required]
        [StringLength(50)]
        public string StudentEmail { get; set; }

        public virtual ICollection<CourseList> CourseLists { get; set; }
    }
}
