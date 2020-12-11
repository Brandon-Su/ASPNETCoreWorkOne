using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreWork.Models;
using ASPNETCoreWork.UpdateModels;
using Omu.ValueInjecter;
namespace ASPNETCoreWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseInstructorController : ControllerBase
    {
        private readonly ContosoUniversityContext _context;
        public CourseInstructorController(ContosoUniversityContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<CourseInstructor>> GetCourseInstructor()
        {
            return _context.CourseInstructor.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<CourseInstructor> GetCourseById(int id)
        {
            return _context.CourseInstructor.Where<CourseInstructor>(p => p.CourseId == id).FirstOrDefault();
        }

        [HttpPost("")]
        public ActionResult<CourseInstructor> PostCourse(CourseInstructor model)
        {
            _context.Add(model);
            _context.SaveChanges();
            return null;
        }

        [HttpPut("{id}")]
        public IActionResult PutCourse(int id, CourseInstructorUpdate model)
        {
            var choose = _context.CourseInstructor.Find(id);
            choose.InjectFrom(model);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<CourseInstructor> DeleteCourseById(int id)
        {
            var choose = _context.CourseInstructor.Find(id);
            _context.CourseInstructor.Remove(choose);
            _context.SaveChanges();
            return null;
        }
    }
}