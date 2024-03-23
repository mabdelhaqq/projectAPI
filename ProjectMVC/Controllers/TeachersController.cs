using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectMVC.Helper;
using ProjectMVC.Models;
using System.Text;

namespace ProjectMVC.Controllers
{
    [Authorize]
    public class TeachersController : Controller
    {
        StudentAPI _api = new StudentAPI();
        private readonly ILogger<TeachersController> _logger;

        public TeachersController(ILogger<TeachersController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<TeacherData> teachers = new List<TeacherData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/teacher");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                teachers = JsonConvert.DeserializeObject<List<TeacherData>>(result);
            }
            return View(teachers);
        }
        public async Task<IActionResult> Details(int id)
        {
            var teacher = new TeacherData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/teacher/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                teacher = JsonConvert.DeserializeObject<TeacherData>(result);
            }
            return View(teacher);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeacherData teacher)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _api.Initial();
                var json = JsonConvert.SerializeObject(teacher);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage res = await client.PostAsync("api/teacher/create", data);
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(teacher);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var teacher = new TeacherData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/teacher/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                teacher = JsonConvert.DeserializeObject<TeacherData>(result);
            }
            return View(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TeacherData teacher)
        {
            if (id != teacher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                HttpClient client = _api.Initial();
                var json = JsonConvert.SerializeObject(teacher);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage res = await client.PutAsync($"api/teacher/update/{id}", data);
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(teacher);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var teacher = new TeacherData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/teacher/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                teacher = JsonConvert.DeserializeObject<TeacherData>(result);
            }
            return View(teacher);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/teacher/delete/{id}");

            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Error", "Home");
        }
    }
}
