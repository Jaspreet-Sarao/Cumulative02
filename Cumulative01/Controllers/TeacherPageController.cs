using Cumulative01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cumulative01.Controllers
{
    public class TeacherPageController : Controller
    {


        private readonly TeacherAPIController _api;

        /// <summary>
        /// Initializes a new instance of the TeacherPageController
        /// </summary>
        /// <param name="api">The TeacherAPIController instance for data access</param>
        public TeacherPageController(TeacherAPIController api)
        {
            _api = api;
        }
        /// <summary>
        /// Displays a list of all teachers
        /// </summary>
        /// <returns>A view containing the list of teachers</returns>
        public IActionResult List()
        {
            List<Teacher> Teach = _api.ListTeacherNames();
            return View(Teach);
        }
        /// <summary>
        /// Displays details for a specific teacher
        /// </summary>
        /// <param name="Id">The ID of the teacher to display</param>
        /// <returns>A view containing the teacher's details</returns>
        /// <example>
        /// GET /TeacherPage/Show/5
        /// </example>
        public IActionResult Show(int Id)
        {

            Teacher teach1 = _api.FindTeacher(Id);
            return View(teach1);
        }
        // GET: TeacherPage/New
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        // POST: TeacherPage/Create
        [HttpPost]
        public IActionResult Create(Teacher NewTeacher)
        {
            int TeacherId = _api.AddTeacher(NewTeacher);
            return RedirectToAction("Show", new { id = TeacherId });
        }

        // GET: TeacherPage/DeleteConfirm/{id}
        [HttpGet]
        public IActionResult DeleteConfirm(int id)
        {
            Teacher SelectedTeacher = _api.FindTeacher(id);
            return View(SelectedTeacher);
        }

        // POST: TeacherPage/Delete/{id}
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _api.DeleteTeacher(id);
            return RedirectToAction("List");
        }
    }
}
  
