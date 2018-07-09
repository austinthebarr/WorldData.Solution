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
      // List<City> allCities = City.GetAll();
      return View(City.GetAll());
    }

    [HttpGet("world/countries")]
    public ActionResult Countries()
    {
      return View(Country.GetAll());
    }

    [HttpGet("world/form")]
    public ActionResult form()
    {
      return View();
    }

    [HttpPost("world/filtered")]
    public ActionResult filtered()
    {
      List<Country> filteredCountry = Country.GetByContinent(Request.Form["continent"]);
      return View(filteredCountry);
    }
  }
}
