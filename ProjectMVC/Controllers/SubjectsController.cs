using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectMVC.Helper;
using ProjectMVC.Models;
using System.Text;

namespace ProjectMVC.Controllers
{
    public class SubjectsController : Controller
    {
        StudentAPI _api = new StudentAPI();
        private readonly ILogger<SubjectsController> _logger;

        public SubjectsController(ILogger<SubjectsController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<SubjectData> subjects = new List<SubjectData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/subject");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                subjects = JsonConvert.DeserializeObject<List<SubjectData>>(result);
            }
            return View(subjects);
        }
        public async Task<IActionResult> Details(int id)
        {
            var subject = new SubjectData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/subject/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                subject = JsonConvert.DeserializeObject<SubjectData>(result);
            }
            return View(subject);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubjectData subject)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _api.Initial();
                var json = JsonConvert.SerializeObject(subject);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage res = await client.PostAsync("api/subject/create", data);
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(subject);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var subject = new SubjectData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/subject/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                subject = JsonConvert.DeserializeObject<SubjectData>(result);
            }
            return View(subject);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, SubjectData subject)
        {
            if (id != subject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                HttpClient client = _api.Initial();
                var json = JsonConvert.SerializeObject(subject);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage res = await client.PutAsync($"api/subject/update/{id}", data);
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(subject);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var subject = new SubjectData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/subject/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                subject = JsonConvert.DeserializeObject<SubjectData>(result);
            }
            return View(subject);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/subject/delete/{id}");

            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Error", "Home");
    }
}
}
