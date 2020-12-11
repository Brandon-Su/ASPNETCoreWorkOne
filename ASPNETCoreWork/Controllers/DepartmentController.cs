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
    public class DepartmentController : ControllerBase
    {
        private readonly ContosoUniversityContext _context;
        private readonly ContosoUniversityContextProcedures _procedure;
        public DepartmentController(ContosoUniversityContext context, ContosoUniversityContextProcedures procedure)
        {
            _context = context;
            _procedure = procedure;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<Department>> GetDepartments()
        {
            return _context.Department.Where(p => p.IsDeleted == false).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Department> GetDepartmentById(int id)
        {
            return _context.Department.Where<Department>(p => p.DepartmentId == id && p.IsDeleted == false).FirstOrDefault();
        }

        [HttpPost("")]
        public ActionResult<Department> PostDepartment(Department model)
        {
            _procedure.Department_Insert(model.Name, model.Budget, model.StartDate, model.InstructorId).Wait();
            return null;
        }

        [HttpPut("{id}")]
        public IActionResult PutDepartment(int id, DepartmentUpdate model)
        {
            var choose = _context.Department.Find(id);
            _procedure.Department_Update(id, model.Name, model.Budget, model.StartDate, model.InstructorId, choose.RowVersion).Wait();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Department> DeleteDepartmentById(int id)
        {
            var choose = _context.Department.Find(id);
            _procedure.Department_Delete(id, choose.RowVersion).Wait();
            return null;
        }

        [HttpGet("DepartmentCourseCount")]
        public ActionResult<IEnumerable<VwDepartmentCourseCount>> GetDepartmentCourseCount()
        {
            return _context.VwDepartmentCourseCount.FromSqlRaw("SELECT * FROM vwDepartmentCourseCount").ToList();
        }
    }
}