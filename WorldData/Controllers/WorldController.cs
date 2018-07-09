using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WorldData.Models;

namespace WorldData.Controllers
{
  public class WorldController : Controller
  {
    [HttpGet("world/cities")]
    public ActionResult Cities()
    {
      List<City> allCities = City.GetAll();
      return View(allCities);
    }
  }
}
