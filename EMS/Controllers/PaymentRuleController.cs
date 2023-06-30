using EMS.Data;
using EMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Controllers
{
    public class PaymentRuleController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PaymentRuleController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<PaymentRule> objPayList = _db.PaymentRules.ToList();
            return View(objPayList);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PaymentRule obj)
        {
            if (ModelState.IsValid)
            {
                _db.PaymentRules.Add(obj);
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
            var payRuleFromDb = _db.PaymentRules.Find(id);

            if (payRuleFromDb == null)
            {
                return NotFound();
            }
            return View(payRuleFromDb);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PaymentRule obj)
        {
            if (ModelState.IsValid)
            {
                _db.PaymentRules.Update(obj);
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
            var payRuleFromDb = _db.PaymentRules.Find(id);

            if (payRuleFromDb == null)
            {
                return NotFound();
            }
            return View(payRuleFromDb);
        }

        //POST - DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.PaymentRules.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.PaymentRules.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
