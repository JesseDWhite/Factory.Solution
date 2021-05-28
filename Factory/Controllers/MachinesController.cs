using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class MachinesController : Controller
  {
    private readonly FactoryContext _db;

    public MachinesController(FactoryContext db)
    {
      _db = db;
    }
    public ActionResult Index()

    {
      List<Machine> model = _db.Machines.ToList();
      return View(model);
    }
    public ActionResult Create()

    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine Machine)
    {
      _db.Machines.Add(Machine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)

    {
      var thisMachine = _db.Machines
      .Include(Machine => Machine.JoinEntities)
      .ThenInclude(join => join.Engineer)
      .FirstOrDefault(Machine => Machine.MachineId == id);
      return View(thisMachine);
    }
    public ActionResult Edit(int id)
    {
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      var thisMachine = _db.Machines.FirstOrDefault(Machine => Machine.MachineId == id);
      return View(thisMachine);
    }
    [HttpPost]

    public ActionResult Edit(Machine Machine)
    {
      _db.Entry(Machine).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddEngineer(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(Machine => Machine.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult AddEngineer(Machine Machine, int EngineerId)
    {
      if (EngineerId != 0)
      {
        _db.MachineEngineers.Add(new MachineEngineer() { EngineerId = EngineerId, MachineId = Machine.MachineId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(Machine => Machine.MachineId == id);
      return View(thisMachine);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(Machine => Machine.MachineId == id);
      _db.Machines.Remove(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult DeleteEngineer(int joinId)
    {
      var JoinEntry = _db.MachineEngineers.FirstOrDefault(entry => entry.MachineEngineerId == joinId);
      _db.MachineEngineers.Remove(JoinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}