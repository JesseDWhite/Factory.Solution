using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class MachineEngineersController : Controller
  {
    private readonly FactoryContext _db;

    public MachineEngineersController(FactoryContext db)
    {
      _db = db;
    }
    public ActionResult Index()

    {
      List<MachineEngineer> model = _db.MachineEngineers.ToList();
      return View(model);
    }
  }
}