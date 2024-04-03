using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using task1.Models;
using task1.Repositories;

namespace task1.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {

        public IcourseRepo Repo { get; set; }
        public ITraineeRepo TRepo { get; set; }
        public CourseController(IcourseRepo repo, ITraineeRepo trepo)
        {
            Repo = repo;
            TRepo = trepo;
        }
        // GET: CourseController
        public ActionResult Index()
        {
         
            return View(Repo.GetAllCourses());
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            return View(Repo.GetCourseByID(id));
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            ViewBag.Trainees = TRepo.GetAllTrainees().ToList();
            return View(new Course());
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course collection)
        {
          
                try
                {
                    Repo.CreateCourse(collection);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            

        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Trainees = TRepo.GetAllTrainees();
            return View(Repo.GetCourseByID(id));
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Course collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Repo.EditCourse(id, collection);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else { return View(); }
        }

        // GET: CourseController/Delete/5
        public ActionResult Delete(int id)
        {
            Repo.DeleteCourse(id);
            return RedirectToAction("Index");
        }



        [HttpPost]
        public IActionResult GetListTwoOptions(dynamic selectedValue)
        {
            var listTwoOptions =Repo.GetAllCourses();
            return Json(listTwoOptions);
        }
    }
}
