using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using projectAPI.Data;
using projectAPI.Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentSubjectController : ControllerBase
    {
        private Context _context;
        public StudentSubjectController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public List<StudentSubject> GetAssigns()
        {
            return _context.StudentSubject.ToList();
        }

        [HttpGet("{id:int}", Name = "GetAssignById")]
        public async Task<ActionResult<StudentSubject>> GetAssignById(int id)
        {
            var assign = await _context.StudentSubject.FindAsync(id);

            if (assign == null)
            {
                return NotFound();
            }

            return assign;
        }

        [HttpPost("create")]
        public ActionResult<Student> CreateStudent([FromBody] StudentSubject model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            StudentSubject assign = new StudentSubject
            {
                StudentId = model.StudentId,
                SubjectId = model.SubjectId,
            };
            _context.StudentSubject.Add(assign);
            _context.SaveChanges();
            model.Id = assign.Id;
            return CreatedAtRoute("GetAssignById", new { id = model.Id }, model);
        }

        [HttpPut("update/{id}")]
        public ActionResult UpdateStudent([FromBody] StudentSubject model)
        {
            if (model == null || model.Id <= 0)
            {
                return BadRequest();
            }
            var existingAssign = _context.StudentSubject.Where(n => n.Id == model.Id).FirstOrDefault();
            if (existingAssign == null)
            {
                return NotFound();
            }
            existingAssign.StudentId = model.StudentId;
            existingAssign.SubjectId = model.SubjectId;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<bool> DeleteAssign(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var assign = _context.StudentSubject.Where((n) => n.Id == id).FirstOrDefault();
            if (assign == null)
            {
                return NotFound();
            }
            _context.StudentSubject.Remove(assign);
            _context.SaveChanges();
            return Ok(true);
        }
    }
}
