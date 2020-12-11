using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreWork.Models;
using ASPNETCoreWork.UpdateModels;
using Omu.ValueInjecter;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ContosoUniversityContext _context;
        public CourseController(ContosoUniversityContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<Course>> GetCourses()
        {
            return _context.Course.Where(p => p.IsDeleted == false).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Course> GetCourseById(int id)
        {
            return _context.Course.Where<Course>(p => p.CourseId == id && p.IsDeleted == false).FirstOrDefault();
        }

        [HttpPost("")]
        public ActionResult<Course> PostCourse(Course model)
        {
            _context.Add(model);
            _context.SaveChanges();
            return null;
        }

        [HttpPut("{id}")]
        public IActionResult PutCourse(int id, CourseUpdate model)
        {
            var choose = _context.Course.Find(id);
            choose.InjectFrom(model);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Course> DeleteCourseById(int id)
        {
            var choose = _context.Course.Find(id);
            choose.IsDeleted = true;
            _context.SaveChanges();
            return null;
        }

        [HttpGet("StudentCount")]
        public ActionResult<IEnumerable<VwCourseStudentCount>> GetStudentCount()
        {
            return _context.VwCourseStudentCount.FromSqlInterpolated($@"SELECT * FROM vwCourseStudents").ToList();
        }

        [HttpGet("Students")]
        public ActionResult<IEnumerable<VwCourseStudents>> GetStudent()
        {
            return _context.VwCourseStudents.FromSqlInterpolated($@"SELECT * FROM vwCourseStudents").ToList();
        }
    }
}