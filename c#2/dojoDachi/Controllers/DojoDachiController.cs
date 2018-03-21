using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dojoDachi.Controllers

{
    public class DojoDachiController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {   
            //happiness
            int? happiness = HttpContext.Session.GetInt32("happiness");
            if(happiness == null)
            {
                HttpContext.Session.SetInt32("happiness", 20);
            }
        
            TempData["happiness"] = HttpContext.Session.GetInt32("happiness");
            //fullness
            int? fullness = HttpContext.Session.GetInt32("fullness");
            if(fullness == null)
            {
                HttpContext.Session.SetInt32("fullness", 20);
            }
        
            TempData["fullness"] = HttpContext.Session.GetInt32("fullness");
            //energy
            int? energy = HttpContext.Session.GetInt32("energy");
            if(energy == null)
            {
                HttpContext.Session.SetInt32("energy", 50);
            }
        
            TempData["energy"] = HttpContext.Session.GetInt32("energy");
            //meals
             int? meals = HttpContext.Session.GetInt32("meals");
            if(meals == null)
            {
                HttpContext.Session.SetInt32("meals", 3);
            }
        
            TempData["meals"] = HttpContext.Session.GetInt32("meals");
        
            return View();
        }

    }

}
