using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;
namespace quotingDojo.Controllers
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
        [Route("addquotes")]
        public IActionResult addQuotes(string name, string quotes)
        {
             // // MySQL query to INSERT data into my Users table
            string insertToDB =  $"INSERT INTO addquotes(name, quotes,  created_at) VALUES ('{name}', '{quotes}', Now() )";
            DbConnector.Execute(insertToDB);
            
            return RedirectToAction("Quotes");
        }
        [HttpGet]
        [Route("quotes")]
        public IActionResult Quotes()
        {
            string query = $"SELECT * FROM addquotes ORDER BY created_at DESC";
            var allquotes = DbConnector.Query(query);
            ViewBag.allquotes = allquotes;
            return View();
            
        }
        
    }
}
