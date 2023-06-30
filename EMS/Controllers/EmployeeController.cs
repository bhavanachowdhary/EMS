using EMS.Data;
using EMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Controllers;

public class EmployeeController : Controller
{
    private readonly ApplicationDbContext _db;

    public EmployeeController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        IEnumerable<EmployeeData> objEmployeeList = _db.Employees.ToList();
        return View(objEmployeeList);
    }

    //GET - CREATE
    public IActionResult Create()
    {
        return View();
    }

    //POST - CREATE
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(EmployeeData obj)
    {
        if (ModelState.IsValid)
        {
            _db.Employees.Add(obj);
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
        var employeeFromDb = _db.Employees.Find(id);

        if (employeeFromDb == null)
        {
            return NotFound();
        }
        return View(employeeFromDb);
    }

    //POST - EDIT
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(EmployeeData obj)
    {
        if (ModelState.IsValid)
        {
            _db.Employees.Update(obj);
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
        var employeeFromDb = _db.Employees.Find(id);

        if (employeeFromDb == null)
        {
            return NotFound();
        }
        return View(employeeFromDb);
    }

    //POST - DELETE
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int? id)
    {
        var obj = _db.Employees.Find(id);
        if (obj == null)
        {
            return NotFound();
        }

        _db.Employees.Remove(obj);
        _db.SaveChanges();
        return RedirectToAction("Index");

    }
}
