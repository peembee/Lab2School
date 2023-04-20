using Lab2School.Data;
using Lab2School.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Design.Internal;
using Microsoft.Identity.Client;
using System.Text;
using Humanizer;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Lab2School.Controllers
{
    public class AssignmentController : Controller
    {

        private readonly SchoolContext schoolContext;
        public AssignmentController(SchoolContext context)
        {
            schoolContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }
       
        public async Task<IActionResult> GetAllEmployees()
        {
            var teacher = await schoolContext.Teachers.ToListAsync();
            var course = await schoolContext.CoursesLists.ToListAsync();

            var getTeacherList = from t in teacher
                                 join c in course on t.TeacherID equals c.FK_TeacherID
                                 where c.FK_CourseID == 1
                                 select t;

            getTeacherList = getTeacherList.DistinctBy(t => t.TeacherID); // Preventing duplications of Teachers

            return View(getTeacherList);
        }

        public async Task<IActionResult> GetAllStudentsAndTeachers()
        {
            var teachers = await schoolContext.Teachers.ToListAsync();
            var students = await schoolContext.Students.ToListAsync();
            var classList = await schoolContext.CoursesLists.ToListAsync();
            var createList = from t in teachers
                             join c in classList on t.TeacherID equals c.FK_TeacherID
                             join s in students on c.FK_StudentID equals s.StudentID
                             orderby c.CourseListID
                             select new StudentTeacher  // Collecting the chosen data to display model
                             {
                                 StudentID = s.StudentID,
                                 StudentName = s.StudentFirstName + " " + s.StudentLastName,
                                 TeacherID = t.TeacherID,
                                 TeacherName = t.TeacherFirstName + " " + t.TeacherLastName,
                             };                           
                
            return View(createList);
        }

        public async Task<IActionResult> GetAllStudentsInCourse()
        {
            var teachers = await schoolContext.Teachers.ToListAsync();
            var students = await schoolContext.Students.ToListAsync();
            var classList = await schoolContext.CoursesLists.ToListAsync();
            var createList = from s in students
                             join c in classList on s.StudentID equals c.FK_StudentID
                             join t in teachers on c.FK_TeacherID equals t.TeacherID
                             where c.FK_CourseID == 1
                             orderby c.CourseListID
                             select new StudentTeacherCourse
                             {
                                 StudentID = s.StudentID,
                                 StudentName = s.StudentFirstName + " " + s.StudentLastName,
                                 TeacherID = t.TeacherID,
                                 TeacherName = t.TeacherFirstName + " " + t.TeacherLastName,
                             };

            return View(createList);
        }
       
        public async Task<IActionResult> EditCourseName()
        {
            var courseList = await schoolContext.Courses.ToListAsync();
            return View(courseList);
        }

        public async Task<IActionResult> EditCourseNameInputs(string courseName, string newCourseName)
        {
            bool found = false;

            courseName = courseName.Trim();
            courseName = courseName.ToLower();

            newCourseName = newCourseName.Trim();
            newCourseName = newCourseName.ToLower();

            var getCourses = await schoolContext.Courses
                            .Where(c => c.CourseName.ToLower() == courseName)
                            .ToListAsync();           

            foreach (var course in getCourses)
            {
                if (course.CourseName.ToLower() == courseName)
                {
                    newCourseName = char.ToUpper(newCourseName[0]) + newCourseName.Substring(1);
                    course.CourseName = newCourseName;
                    found = true;                    
                    schoolContext.SaveChanges();
                }                
            }

            if (!found)
            {
                return View("NoMatch");
            }
            else
            {
                return View(getCourses);
            }
        }



        public IActionResult UpdateTeacher()
        {
            return View();
        }

        public async Task<IActionResult> UpdateTeacherInput(string newTeacherName, string oldTeacherName)
        {
            bool found = false;
            // TextFormat. First letter capital.
            newTeacherName = newTeacherName.Trim();
            newTeacherName = newTeacherName.ToLower();
            newTeacherName = char.ToUpper(newTeacherName[0]) + newTeacherName.Substring(1);

            oldTeacherName = oldTeacherName.Trim();
            oldTeacherName = oldTeacherName.ToLower();
            oldTeacherName = char.ToUpper(oldTeacherName[0]) + oldTeacherName.Substring(1);


            var teacher = await schoolContext.Teachers
                .Include(t => t.CourseLists)
                .ToListAsync();

            foreach (var item in teacher)
            {
                if (item.TeacherFirstName == oldTeacherName)  // search for matching names
                {
                    foreach (var Id in item.CourseLists) // if match = check if teacherID have that course via fk-CourseID
                    {
                        if (item.TeacherID == Id.FK_TeacherID && Id.FK_CourseID == 1)
                        {
                            item.TeacherFirstName = newTeacherName; // if match, change firstname on teacher
                            schoolContext.SaveChanges();
                            found = true;
                            break;
                        }
                    }
                }
                if (found)
                {
                    break;
                }
            }

            if (found)
            {
                return View("UpdateTeacherResult");
            }
            else
            {
                return View("NoMatch");
            }
        }
    }
}
