using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projectAPI.Data;
using projectAPI.Models;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SubjectController : ControllerBase
    {
        private Context _context;
        public SubjectController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        public List<Subject> GetSubjects()
        {
            return _context.Subject.ToList();
        }

        [HttpGet("{id:int}", Name = "GetSubjectById")]
        public async Task<ActionResult<Subject>> GetSubject(int id)
        {
            var subject = await _context.Subject.FindAsync(id);

            if (subject == null)
            {
                return NotFound();
            }

            return subject;
        }

        [HttpPost("create")]
        public ActionResult<Subject> CreateSubject([FromBody] Subject model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            Subject subject = new Subject
            {
                Name = model.Name,
                Description = model.Description,
            };
            _context.Subject.Add(subject);
            _context.SaveChanges();
            model.Id = subject.Id;
            return CreatedAtRoute("GetSubjectById", new { id = model.Id }, model);
        }

        [HttpPut("update/{id}")]
        public ActionResult UpdateSubject([FromBody] Subject model)
        {
            if (model == null || model.Id <= 0)
            {
                return BadRequest();
            }
            var existingSubject = _context.Subject.Where(n => n.Id == model.Id).FirstOrDefault();
            if (existingSubject == null)
            {
                return NotFound();
            }
            existingSubject.Name = model.Name;
            existingSubject.Description = model.Description;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<bool> DeleteSubject(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var Subject = _context.Subject.Where((n) => n.Id == id).FirstOrDefault();
            if (Subject == null)
            {
                return NotFound();
            }
            _context.Subject.Remove(Subject);
            _context.SaveChanges();
            return Ok(true);
        }
    }
}
