using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BankAccounts.Models;
using System.Linq;
namespace BankAccounts.Controllers
{
    public class HomeController : Controller
    {
        private AccountsContext _context;

        public HomeController(AccountsContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterViewModel user)
        {
            if(ModelState.IsValid)
            {
               User findEmail = _context.Users.Where(e => e.Email == user.Email).SingleOrDefault();
                if(findEmail == null)
                {
                    User NewUser = new User
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Password = user.Password,
                        CreatedAt= DateTime.Now,
                        UpdatedAt=DateTime.Now

                    };
                    _context.Add(NewUser);
                    _context.SaveChanges();
                    int intID = (int)NewUser.UserId;               
                    HttpContext.Session.SetInt32("UserId", intID);
                    return RedirectToAction("Success");
                }
               
            }   
            ViewBag.Email="Email is already exists in the system. Use another email or login.";      
            return View("Index");
        }
        [HttpGet]
        [Route("login")]
         public IActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        [Route("signin")]
         public IActionResult Signin(User LoginUser)
        {
            if(ModelState.IsValid)
            {
                // MySQL query to INSERT data into my Users table
               User findEmail = _context.Users.Where(e => e.Email == LoginUser.Email).SingleOrDefault();
                
                 System.Console.WriteLine(findEmail);
                if(findEmail == null)
                {
                    System.Console.WriteLine("+++++++++++",findEmail);
                    ViewBag.Email="Email not found";
                    return View("Login");
                    
                }
               
                string matchPass = (findEmail.Password).ToString();
                if(matchPass!=LoginUser.Password)
                {
                    ViewBag.Password="Incorrect password";
                    return View("Login");
                }
                else
                {
                    // System.Console.WriteLine("+++++++++++++" + sendingId);
                    int intID = (int)LoginUser.UserId; 
                    // System.Console.WriteLine("+++++++++++" + intID + "+++++++++ INT ID!!!");              
                    HttpContext.Session.SetInt32("UserId", intID);
                    return RedirectToAction("Success");         

                }
                    
                
            } 

            return View("Login");
        }
        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            // int? attempt = HttpContext.Session.GetInt32("attempt");
            // if(attempt == null)
            // {
            //     HttpContext.Session.SetInt32("attempt", 1);
            // }
            // else
            // {
            //     attempt += 1;
            //     HttpContext.Session.SetInt32("attempt", (int)attempt);
            // }
        
            // TempData["attempt"] = HttpContext.Session.GetInt32("attempt");
            return View();
        }
    }
}
