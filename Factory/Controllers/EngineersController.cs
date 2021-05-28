using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    public ActionResult Index()
    {
      return View(_db.Engineers.ToList());
    }

    public ActionResult Details(int id)
    {
      var thisEngineer = _db.Engineers
        .Include(Engineer => Engineer.JoinEntities)
        .ThenInclude(join => join.Machine)
        .FirstOrDefault(Engineer => Engineer.EngineerId == id);
      return View(thisEngineer);
    }

    private readonly FactoryContext _db;

    public EngineersController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Create()
    {
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer Engineer, int MachineId)
    {
      _db.Engineers.Add(Engineer);
      _db.SaveChanges();
      if (MachineId != 0)
      {
        _db.MachineEngineers.Add(new MachineEngineer() { MachineId = MachineId, EngineerId = Engineer.EngineerId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(Engineer => Engineer.EngineerId == id);
      ViewBag.MachineId = new MultiSelectList(_db.Machines, "MachineId", "Name");
      return View(thisEngineer);
    }
    [HttpPost]
    public ActionResult Edit(Engineer Engineer, int MachineId)
    {
      if (MachineId != 0)
      {

        _db.MachineEngineers.Add(new MachineEngineer() { MachineId = MachineId, EngineerId = Engineer.EngineerId });
      }
      _db.Entry(Engineer).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddMachine(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(Engineer => Engineer.EngineerId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult AddMachine(Engineer Engineer, int MachineId)
    {
      if (MachineId != 0)
      {
        _db.MachineEngineers.Add(new MachineEngineer() { MachineId = MachineId, EngineerId = Engineer.EngineerId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(Engineer => Engineer.EngineerId == id);
      return View(thisEngineer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(Engineer => Engineer.EngineerId == id);
      _db.Engineers.Remove(thisEngineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteMachine(int joinId)
    {
      var JoinEntry = _db.MachineEngineers.FirstOrDefault(entry => entry.MachineEngineerId == joinId);
      _db.MachineEngineers.Remove(JoinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}