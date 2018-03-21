using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;
namespace ajaxNotes.Controllers
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
        [Route("addnotes")]
        public IActionResult addQuotes(string title, string notes)
        {
             // // MySQL query to INSERT data into my Users table
            string insertToDB =  $"INSERT INTO notes(title,  description, created_at) VALUES ('{title}', '{notes}', Now() )";
            DbConnector.Execute(insertToDB);
            
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("edit")]
        public IActionResult Edit(string notes)
        {
            string update = $"SELECT description SET {notes}";
            DbConnector.Execute(update);
            return RedirectToAction("Index");
            
        }
        [HttpGet]
        [Route("delete")]
        public IActionResult delete()
        {
            string delete = $"DELETE FROM notes where id=id";
            DbConnector.Execute(delete);
            
            return View();    
        }
    }
}
