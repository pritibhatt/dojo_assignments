using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using formSubmission.Models;

namespace formSubmission.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
         public IActionResult Index()
        {
            ViewBag.Errors=ModelState.Values;
            return View();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(string fName, string lName, string email, int age, string password)
        {
             User NewUser = new User
            {
                FirstName = fName,
                LastName = lName,
                Age = age,
                Email = email,
                Password = password
            };
            if(TryValidateModel(NewUser)==false)
            {
                ViewBag.Errors = ModelState.Values;
                return View("Index");
            }
            return RedirectToAction("Sucess");
        }
         [HttpGet]
        [Route("sucess")]
         public IActionResult Sucess()
        {
           
            return View();
        }
    }
}
