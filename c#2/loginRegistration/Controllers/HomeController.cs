using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using loginRegistration.Models;
using DbConnection;
namespace loginRegistration.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(User user)
        {
            if(ModelState.IsValid)
            {
                // MySQL query to INSERT data into my Users table
                string insertToDB =  $"INSERT INTO user(firstName, lastName, email, password) VALUES ('{user.FirstName}', '{user.LastName}','{user.Email}', '{user.Password}' )";
                DbConnector.Execute(insertToDB);
                return RedirectToAction("Sucess");
            }
            
            
            return View("Index");
           
            
        }
        [HttpGet]
        [Route("sucess")]
         public IActionResult Sucess()
        {
           
            return View();
        }
        [HttpGet]
        [Route("login")]
         public IActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        [Route("signin")]
         public IActionResult Signin(LoginUser user)
        {
            if(ModelState.IsValid)
            {
                // MySQL query to INSERT data into my Users table
                string insertToDB =  $"SELECT * FROM user WHERE(email = '{user.Email}' )";
                var matchEmail = DbConnector.Query(insertToDB);         
                if(matchEmail.Count == 0 )
                {
                    System.Console.WriteLine(matchEmail);
                    ViewBag.Email="Email not found";
                    return View("Login");
                    
                }
               
                string matchPass = (matchEmail[0]["password"]).ToString();
                if(matchPass!=user.Password)
                {
                    ViewBag.Password="Incorrect password";
                    return View("Login");
                }
                else
                {
                    return RedirectToAction("Sucess");         

                }
                    
                
            }    
          
           return View("Login");
        }
    }
}
