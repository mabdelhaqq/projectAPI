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
    public class TeacherController : ControllerBase
    {
        private Context _context;
        public TeacherController(Context context)
        {
            _context = context;
        }
        [HttpGet]
   
        public List<Teacher> GetTeachers()
        {
            return _context.Teacher.ToList();
        }

        [HttpGet("{id:int}", Name = "GetTeacherById")]
        public async Task<ActionResult<Teacher>> GetTeacher(int id)
        {
            var teacher = await _context.Teacher.FindAsync(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return teacher;
        }

        [HttpPost("create")]

        public ActionResult<Teacher> CreateTeacher([FromBody] Teacher model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            Teacher teacher = new Teacher
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
            };
            _context.Teacher.Add(teacher);
            _context.SaveChanges();
            model.Id = teacher.Id;
            return CreatedAtRoute("GetTeacherById", new { id = model.Id }, model);
        }

        [HttpPut("update/{id}")]
        public ActionResult UpdateTeacher([FromBody] Teacher model)
        {
            if (model == null || model.Id <= 0)
            {
                return BadRequest();
            }
            var existingTeacher = _context.Teacher.Where(n => n.Id == model.Id).FirstOrDefault();
            if (existingTeacher == null)
            {
                return NotFound();
            }
            existingTeacher.FirstName = model.FirstName;
            existingTeacher.LastName = model.LastName;
            existingTeacher.Email = model.Email;
            existingTeacher.PhoneNumber = model.PhoneNumber;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<bool> DeleteTeacher(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var Teacher = _context.Teacher.Where((n) => n.Id == id).FirstOrDefault();
            if (Teacher == null)
            {
                return NotFound();
            }
            _context.Teacher.Remove(Teacher);
            _context.SaveChanges();
            return Ok(true);
        }

    }
}
