using EMS.Data;
using EMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Controllers
{
    public class DesignationController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DesignationController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Designation> objDesignationList = _db.Designations.ToList();
            return View(objDesignationList);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Designation obj)
        {
            if (ModelState.IsValid)
            {
                _db.Designations.Add(obj);
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
            var designationFromDb = _db.Designations.Find(id);

            if (designationFromDb == null)
            {
                return NotFound();
            }
            return View(designationFromDb);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Designation obj)
        {
            if (ModelState.IsValid)
            {
                _db.Designations.Update(obj);
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
            var designationFromDb = _db.Designations.Find(id);

            if (designationFromDb == null)
            {
                return NotFound();
            }
            return View(designationFromDb);
        }

        //POST - DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Designations.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Designations.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
