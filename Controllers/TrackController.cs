using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using task1.Models;
using task1.Repositories;

namespace task1.Controllers
{
    [Authorize]
    [Route("Track")]
    public class TrackController : Controller
    {

        public ITrackRepo TrackRepo { get; set; }
        public TrackController(ITrackRepo trackrepo)
        {
            TrackRepo = trackrepo;
        }

        // GET: TrackController
        [Route("AllTracks")]
        [Route("")]
        public ActionResult Index()
        {
            return View(TrackRepo.GetAllTracks());
        }

        // GET: TrackController/Details/5
        [Route("Details/{id:int:min(10)}")]
        public ActionResult Details(int id)
        {
            return View(TrackRepo.GetTrackByID(id));
        }

        // GET: TrackController/Create
        [Route("Create")]
        public ActionResult Create()
        {
            return View(new Track());
        }

        // POST: TrackController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create/{createTrack}")]
        public ActionResult Create(Track createTrack)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TrackRepo.CreateTrack(createTrack);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else { return View(); }
        }

        // GET: TrackController/Edit/5
        [HttpGet]
        [Route("Edit/{id:int:min(10)}")]
        public ActionResult Edit(int id)
        {
            return View(TrackRepo.GetTrackByID(id));
        }

        //POST: TrackController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id:int:min(10)}")]
        public ActionResult Edit(int id, Track editTrack)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TrackRepo.EditTrack(id, editTrack);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else { return View(); }
        }

        // GET: TrackController/Delete/5
        [Route("Delete/{id:int:min(10)}")]
        public ActionResult Delete(int id)
        {
            TrackRepo.DeleteTrack(id);
            return RedirectToAction("Index");
        }


    }
}

