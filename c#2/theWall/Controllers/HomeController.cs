using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using theWall.Models;
using DbConnection;
namespace theWall.Controllers
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
                string insertToDB =  $"INSERT INTO users(firstName, lastName, email, password, created_at, updated_ar) VALUES ('{user.FirstName}', '{user.LastName}','{user.Email}', '{user.Password}', Now(), Now() )";
                DbConnector.Execute(insertToDB);
                // System.Console.WriteLine("+++++++++++++" + user);
                string findId =  $"SELECT id FROM users WHERE(email = '{user.Email}' )";
                var sendingId = DbConnector.Query(findId);
                // System.Console.WriteLine("+++++++++++++" + sendingId);
                int intID = (int)sendingId[0]["id"];
               
                HttpContext.Session.SetInt32("id", intID);
                
                return RedirectToAction("Success");
            }
            
            
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
         public IActionResult Signin(LoginUser user)
        {
            if(ModelState.IsValid)
            {
                // MySQL query to INSERT data into my Users table
                string insertToDB =  $"SELECT * FROM users WHERE(email = '{user.Email}' )";
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
                    // System.Console.WriteLine("+++++++++++++" + sendingId);
                    int intID = (int)matchEmail[0]["id"];               
                    HttpContext.Session.SetInt32("id", intID);
                    return RedirectToAction("Success");         

                }
                    
                
            }    
          
           return View("Login");
        }
        [HttpPost]
        [Route("addmessage")]
        public IActionResult addMessage(string message)
        {
             // // MySQL query to INSERT data into my Users table
            int? userID = HttpContext.Session.GetInt32("id");
            string insertmessagequery = $"INSERT INTO messages (message, Users_id, created_at, updated_at) VALUES ('{message}', '{userID}', Now(), Now())";
            DbConnector.Execute(insertmessagequery);
            // string findmessages = $"SELECT * FROM messages  INNER JOIN users ORDER BY created_at DESC";
            // var allmessages = DbConnector.Query(findmessages);
            // ViewBag.allmessages = allmessages;
            return RedirectToAction("Success");
            
        }
        [HttpPost]
        [Route("addcomment")]
        public IActionResult addComment(string comment)
        {
             // // MySQL query to INSERT data into my Users table
            int? userID = HttpContext.Session.GetInt32("id");
            string insertcommentquery = $"INSERT INTO comments (comment, Users_id, created_at, updated_at) VALUES ('{comment}', '{userID}', Now(), Now())";
            DbConnector.Execute(insertcommentquery);
            // string findcomments= $"SELECT * FROM comments";
            // var allcomments = DbConnector.Query(findcomments);
            // ViewBag.allcomments = allcomments;
           
            return RedirectToAction("Success");
            
        }
        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            // string query = $"SELECT * FROM messages  INNER JOIN users ORDER BY created_at DESC";
            string query = $"SELECT * FROM thewall.messages ORDER BY created_at DESC";
            var allmessages = DbConnector.Query(query);
            ViewBag.allmessages = allmessages;
            return View();
            
        }
    }
}

