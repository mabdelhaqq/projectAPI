using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ProjectMVC.Helper;
using ProjectMVC.Models;
using System.Text;

namespace ProjectMVC.Controllers
{
    public class StudentSubjectsController : Controller
    {
        StudentAPI _api = new StudentAPI();
        private readonly ILogger<StudentSubjectsController> _logger;

        public StudentSubjectsController(ILogger<StudentSubjectsController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<StudentSubjectData> studentSubjects = new List<StudentSubjectData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/studentsubject");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                studentSubjects = JsonConvert.DeserializeObject<List<StudentSubjectData>>(result);

                foreach (var studentSubject in studentSubjects)
                {
                    HttpResponseMessage studentRes = await client.GetAsync($"api/student/{studentSubject.StudentId}");
                    if (studentRes.IsSuccessStatusCode)
                    {
                        var studentResult = studentRes.Content.ReadAsStringAsync().Result;
                        studentSubject.Student = JsonConvert.DeserializeObject<StudentData>(studentResult);
                    }
                    HttpResponseMessage subjectRes = await client.GetAsync($"api/subject/{studentSubject.SubjectId}");
                    if (subjectRes.IsSuccessStatusCode)
                    {
                        var subjectResult = subjectRes.Content.ReadAsStringAsync().Result;
                        studentSubject.Subject = JsonConvert.DeserializeObject<SubjectData>(subjectResult);
                    }
                }
            }

            return View(studentSubjects);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            HttpClient client = _api.Initial();
            var studentsRes = await client.GetAsync("api/student");
            if (studentsRes.IsSuccessStatusCode)
            {
                var studentsResult = await studentsRes.Content.ReadAsStringAsync();
                var students = JsonConvert.DeserializeObject<List<StudentData>>(studentsResult);
                ViewData["Students"] = new SelectList(students, "Id", "Id");
            }

            var subjectsRes = await client.GetAsync("api/subject");
            if (subjectsRes.IsSuccessStatusCode)
            {
                var subjectsResult = await subjectsRes.Content.ReadAsStringAsync();
                var subjects = JsonConvert.DeserializeObject<List<SubjectData>>(subjectsResult);
                ViewData["Subjects"] = new SelectList(subjects, "Id", "Id");
            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentSubjectData studentSubject)
        {
            HttpClient client = _api.Initial();

            if (!ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(studentSubject);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage res = await client.PostAsync("api/studentsubject/create", data);
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            var studentsRes = await client.GetAsync("api/student");
            if (studentsRes.IsSuccessStatusCode)
            {
                var studentsResult = await studentsRes.Content.ReadAsStringAsync();
                var students = JsonConvert.DeserializeObject<List<StudentData>>(studentsResult);
                ViewData["Students"] = new SelectList(students, "Id", "Id", studentSubject.StudentId);
            }

            var subjectsRes = await client.GetAsync("api/subject");
            if (subjectsRes.IsSuccessStatusCode)
            {
                var subjectsResult = await subjectsRes.Content.ReadAsStringAsync();
                var subjects = JsonConvert.DeserializeObject<List<SubjectData>>(subjectsResult);
                ViewData["Subjects"] = new SelectList(subjects, "Id", "Id", studentSubject.SubjectId);
            }

            return View(studentSubject);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var assign = new StudentSubjectData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/studentsubject/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                assign = JsonConvert.DeserializeObject<StudentSubjectData>(result);
            }
            var studentsRes = await client.GetAsync("api/student");
            if (studentsRes.IsSuccessStatusCode)
            {
                var studentsResult = await studentsRes.Content.ReadAsStringAsync();
                var students = JsonConvert.DeserializeObject<List<StudentData>>(studentsResult);
                ViewData["Students"] = new SelectList(students, "Id", "Id");
            }

            var subjectsRes = await client.GetAsync("api/subject");
            if (subjectsRes.IsSuccessStatusCode)
            {
                var subjectsResult = await subjectsRes.Content.ReadAsStringAsync();
                var subjects = JsonConvert.DeserializeObject<List<SubjectData>>(subjectsResult);
                ViewData["Subjects"] = new SelectList(subjects, "Id", "Id");
            }
            return View(assign);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StudentSubjectData studentSubject)
        {
            HttpClient client = _api.Initial();

            if (!ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(studentSubject);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage res = await client.PutAsync($"api/studentsubject/update/{studentSubject.Id}", data);
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            var studentsRes = await client.GetAsync("api/student");
            if (studentsRes.IsSuccessStatusCode)
            {
                var studentsResult = await studentsRes.Content.ReadAsStringAsync();
                var students = JsonConvert.DeserializeObject<List<StudentData>>(studentsResult);
                ViewData["Students"] = new SelectList(students, "Id", "Id", studentSubject.StudentId);
            }

            var subjectsRes = await client.GetAsync("api/subject");
            if (subjectsRes.IsSuccessStatusCode)
            {
                var subjectsResult = await subjectsRes.Content.ReadAsStringAsync();
                var subjects = JsonConvert.DeserializeObject<List<SubjectData>>(subjectsResult);
                ViewData["Subjects"] = new SelectList(subjects, "Id", "Id", studentSubject.SubjectId);
            }

            return View(studentSubject);
        }





        public async Task<IActionResult> Details(int id)
        {
            var assign = new StudentSubjectData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/studentsubject/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                assign = JsonConvert.DeserializeObject<StudentSubjectData>(result);
                HttpResponseMessage studentRes = await client.GetAsync($"api/student/{assign.StudentId}");
                if (studentRes.IsSuccessStatusCode)
                {
                    var studentResult = studentRes.Content.ReadAsStringAsync().Result;
                    assign.Student = JsonConvert.DeserializeObject<StudentData>(studentResult);
                }
                HttpResponseMessage subjectRes = await client.GetAsync($"api/subject/{assign.SubjectId}");
                if (subjectRes.IsSuccessStatusCode)
                {
                    var subjectResult = subjectRes.Content.ReadAsStringAsync().Result;
                    assign.Subject = JsonConvert.DeserializeObject<SubjectData>(subjectResult);
                }
            }
            return View(assign);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var assign = new StudentSubjectData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/studentsubject/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                assign = JsonConvert.DeserializeObject<StudentSubjectData>(result);
                HttpResponseMessage studentRes = await client.GetAsync($"api/student/{assign.StudentId}");
                if (studentRes.IsSuccessStatusCode)
                {
                    var studentResult = studentRes.Content.ReadAsStringAsync().Result;
                    assign.Student = JsonConvert.DeserializeObject<StudentData>(studentResult);
                }
                HttpResponseMessage subjectRes = await client.GetAsync($"api/subject/{assign.SubjectId}");
                if (subjectRes.IsSuccessStatusCode)
                {
                    var subjectResult = subjectRes.Content.ReadAsStringAsync().Result;
                    assign.Subject = JsonConvert.DeserializeObject<SubjectData>(subjectResult);
                }
            }
            return View(assign);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/studentsubject/delete/{id}");

            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Error", "Home");
        }
    }
}
