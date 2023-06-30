using EMS.Data;
using EMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Controllers
{
    public class WorkHoursController : Controller
    {
        private readonly ApplicationDbContext _db;

        public WorkHoursController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<WorkHours> objWorkList = _db.WorkHours.ToList();
            return View(objWorkList);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(WorkHours obj)
        {
            if (ModelState.IsValid)
            {
                _db.WorkHours.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var workHourFromDb = _db.WorkHours.Find(id);

            if (workHourFromDb == null)
            {
                return NotFound();
            }
            return View(workHourFromDb);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(WorkHours obj)
        {
            if (ModelState.IsValid)
            {
                _db.WorkHours.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var workHourFromDb = _db.WorkHours.Find(id);

            if (workHourFromDb == null)
            {
                return NotFound();
            }
            return View(workHourFromDb);
        }

        //POST - DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.WorkHours.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.WorkHours.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
