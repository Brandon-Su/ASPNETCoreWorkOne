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
    public class PersonController : ControllerBase
    {
        private readonly ContosoUniversityContext _context;
        public PersonController(ContosoUniversityContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<Person>> GetPersons()
        {
            return _context.Person.Where(p => p.IsDeleted==false).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Person> GetPersonById(int id)
        {
            return _context.Person.Where<Person>(p => p.Id == id &&  p.IsDeleted == false).FirstOrDefault();
        }

        [HttpPost("")]
        public ActionResult<Person> PostPerson(Person model)
        {
            _context.Add(model);
            _context.SaveChanges();
            return null;
        }

        [HttpPut("{id}")]
        public IActionResult PutPerson(int id, PersonUpdate model)
        {
            var choose = _context.Person.Find(id);
            choose.InjectFrom(model);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Person> DeletePersonById(int id)
        {
            var choose = _context.Person.Find(id);
            choose.IsDeleted = true;
            _context.SaveChanges();
            return null;
        }


    }
}