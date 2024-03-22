using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectAPI.Data;
using projectAPI.Models;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private Context _context;
        public StudentController(Context context) { 
            _context = context;
        }
        [HttpGet]
        public List<Student> GetStudents()
        {
            return _context.Student.ToList();
        }

        [HttpGet("{id:int}", Name = "GetStudentById")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Student.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        [HttpPost("create")]
        public ActionResult<Student> CreateStudent([FromBody] Student model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            Student student = new Student
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Adress = model.Adress,
                PhoneNumber = model.PhoneNumber,
            };
            _context.Student.Add(student);
            _context.SaveChanges();
            model.Id = student.Id;
            return CreatedAtRoute("GetStudentById", new { id = model.Id }, model);
        }

        [HttpPut("update/{id}")]
        public ActionResult UpdateStudent([FromBody] Student model)
        {
            if (model == null || model.Id <= 0)
            {
                return BadRequest();
            }
            var existingStudent = _context.Student.Where(n => n.Id == model.Id).FirstOrDefault();
            if (existingStudent == null)
            {
                return NotFound();
            }
            existingStudent.FirstName = model.FirstName;
            existingStudent.LastName = model.LastName;
            existingStudent.Email = model.Email;
            existingStudent.Adress = model.Adress;
            existingStudent.PhoneNumber = model.PhoneNumber;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<bool> DeleteStudent(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var Student = _context.Student.Where((n) => n.Id == id).FirstOrDefault();
            if (Student == null)
            {
                return NotFound();
            }
            _context.Student.Remove(Student);
            _context.SaveChanges();
            return Ok(true);
        }
    }
}
