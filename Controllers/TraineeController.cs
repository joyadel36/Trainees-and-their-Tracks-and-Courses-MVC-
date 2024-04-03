using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using task1.Models;
using task1.Repositories;

namespace task1.Controllers
{

   
    [Authorize]
    public class TraineeController : Controller
    {

        public ITraineeRepo Repo { get; set; }
        public ITrackRepo TrackRepo { get; set; }
        public TraineeController(ITraineeRepo repo, ITrackRepo trackrepo)
        {
            Repo = repo;
            TrackRepo = trackrepo;
        }
        // GET: TraineeController

        public ActionResult Index()
        {
            return View(Repo.GetAllTrainees());
        }

        // GET: TraineeController/Details/5
        public ActionResult Details(int id)
        {
            return View(Repo.GetTraineeByID(id));
        }

        // GET: TraineeController/Create
        public ActionResult Create()
        {
            ViewBag.tracks = new SelectList(TrackRepo.GetAllTracks(), "ID", "Name");
            return View(new Trainee());
        }

        // POST: TraineeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trainee collection)
        {
            ViewBag.tracks = new SelectList(TrackRepo.GetAllTracks(), "ID", "Name");
            try
                {
                    Repo.CreateTrainee(collection);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
          
        }

        // GET: TraineeController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.tracks =new SelectList( TrackRepo.GetAllTracks(),"ID","Name",id);
            return View(Repo.GetTraineeByID(id));
        }

        // POST: TraineeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Trainee collection)
        {
            ViewBag.tracks = new SelectList(TrackRepo.GetAllTracks(), "ID", "Name", id);
         
                try
                {
                    Repo.EditTrainee(id, collection);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
          
        }

        // GET: TraineeController/Delete/5
        public ActionResult Delete(int id)
        {
            Repo.DeleteTrainee(id);
            return RedirectToAction("Index");
        }

      
    }
}
