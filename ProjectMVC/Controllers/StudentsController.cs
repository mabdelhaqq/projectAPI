using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectMVC.Helper;
using ProjectMVC.Models;
using System.Diagnostics;
using System.Text;

namespace ProjectMVC.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        StudentAPI _api = new StudentAPI();
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ILogger<StudentsController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<StudentData> students = new List<StudentData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/student");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                students = JsonConvert.DeserializeObject<List<StudentData>>(result);
            }
            return View(students);
        }
        public async Task<IActionResult> Details(int id)
        {
            var student = new StudentData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/student/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                student = JsonConvert.DeserializeObject<StudentData>(result);
            }
            return View(student);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentData student)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _api.Initial();
                var json = JsonConvert.SerializeObject(student);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage res = await client.PostAsync("api/student/create", data);
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(student);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var student = new StudentData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/student/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                student = JsonConvert.DeserializeObject<StudentData>(result);
            }
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, StudentData student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                HttpClient client = _api.Initial();
                var json = JsonConvert.SerializeObject(student);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage res = await client.PutAsync($"api/student/update/{id}", data);
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(student);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var student = new StudentData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/student/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                student = JsonConvert.DeserializeObject<StudentData>(result);
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/student/delete/{id}");

            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Error", "Home");
        }
    }
}
