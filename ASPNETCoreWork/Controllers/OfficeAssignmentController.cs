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
    public class OfficeAssignmentController : ControllerBase
    {
        private readonly ContosoUniversityContext _context;
        public OfficeAssignmentController(ContosoUniversityContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<OfficeAssignment>> GetOfficeAssignments()
        {
            return _context.OfficeAssignment.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<OfficeAssignment> GetOfficeAssignmentById(int id)
        {
            return _context.OfficeAssignment.Where<OfficeAssignment>(p => p.InstructorId == id).FirstOrDefault();
        }

        [HttpPost("")]
        public ActionResult<OfficeAssignment> PostOfficeAssignment(OfficeAssignment model)
        {
            _context.Add(model);
            _context.SaveChanges();
            return null;
        }

        [HttpPut("{id}")]
        public IActionResult PutOfficeAssignment(int id, OfficeAssignmentUpdate model)
        {
            var choose = _context.OfficeAssignment.Find(id);
            choose.InjectFrom(model);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<OfficeAssignment> DeleteOfficeAssignmentById(int id)
        {
            var choose = _context.OfficeAssignment.Find(id);
            _context.OfficeAssignment.Remove(choose);
            _context.SaveChanges();
            return null;
        }
    }
}