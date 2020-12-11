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
    public class EnrollmentController : ControllerBase
    {
        private readonly ContosoUniversityContext _context;
        public EnrollmentController(ContosoUniversityContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<Enrollment>> GetEnrollments()
        {
            return _context.Enrollment.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Enrollment> GetEnrollmentById(int id)
        {
            return _context.Enrollment.Where<Enrollment>(p => p.EnrollmentId == id).FirstOrDefault();
        }

        [HttpPost("")]
        public ActionResult<Enrollment> PostEnrollment(Enrollment model)
        {
            _context.Add(model);
            _context.SaveChanges();
            return null;
        }

        [HttpPut("{id}")]
        public IActionResult PutEnrollment(int id, EnrollmentUpdate model)
        {
            var choose = _context.Enrollment.Find(id);
            choose.InjectFrom(model);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Enrollment> DeleteEnrollmentById(int id)
        {
            var choose = _context.Enrollment.Find(id);
            _context.Enrollment.Remove(choose);
            _context.SaveChanges();
            return null;
        }
    }
}