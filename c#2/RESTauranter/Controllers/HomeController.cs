using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RESTauranter.Models;
using System.Linq;


namespace RESTauranter.Controllers
{
    
    public class HomeController : Controller
    {
        private ReviewContext _context;

        public HomeController(ReviewContext context)
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
        [Route("createReview")]
        public IActionResult createReview(Reviews newReview)
        {
            if(ModelState.IsValid){
                _context.Add(newReview);
                _context.SaveChanges();
                return RedirectToAction("Reviews");
            }
            return View("Index");
    
        }
        [HttpGet]
        [Route("reviews")]
        public IActionResult Reviews()
        {
            List<Reviews> allreviews = _context.reviews.OrderByDescending(r=>r.Reviews).ToList();
            ViewBag.Reviews=allreviews;
            return View();
        }
    }
}
