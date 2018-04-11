using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;
using System.Linq;
namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private WeddingPlannerContext _context;

        public HomeController(WeddingPlannerContext context)
        {
            _context = context;
        }
        // GET: /Home/

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                User findEmail = _context.Users.Where(e => e.Email == user.Email).SingleOrDefault();
                if (findEmail == null)
                {
                    User NewUser = new User
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Password = user.Password,
                        // CreatedAt = DateTime.Now,
                        // UpdatedAt = DateTime.Now

                    };
                    _context.Add(NewUser);
                    _context.SaveChanges();
                    int intID = (int)NewUser.UserId;
                    HttpContext.Session.SetInt32("UserId", intID);
                    return RedirectToAction("Success");
                }
                else
                {
                    ViewBag.Email = "Email is already exists in the system. Use another email or login.";
                    return View("Index");

                }

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
        public IActionResult Signin(User LoginUser)
        {
            if (ModelState.IsValid)
            {
                // MySQL query to INSERT data into my Users table
                User findEmail = _context.Users.Where(e => e.Email == LoginUser.Email).SingleOrDefault();

                //  System.Console.WriteLine("++++++findemail" + findEmail);
                if (findEmail == null)
                {

                    ViewBag.Email = "Email not found";
                    return View("Login");

                }
                string matchPass = (findEmail.Password).ToString();
                if (matchPass != LoginUser.Password)
                {
                    ViewBag.Password = "Incorrect password";
                    return View("Login");
                }
                else
                {
                    // System.Console.WriteLine("+++++++++++++" + sendingId);
                    int intID = (int)findEmail.UserId;
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
            int? userInfo = HttpContext.Session.GetInt32("UserId");
            ViewBag.userInfo = userInfo;
            User findUserInfo = _context.Users.Where(e => e.UserId == userInfo).SingleOrDefault();
            // System.Console.WriteLine(findUserInfo);
            ViewBag.findUserInfo = findUserInfo;
            List<Wedding> allAweddingInfo = _context.Weddings.Include(r => r.RSVP).ThenInclude(u => u.User).ToList();
            // System.Console.WriteLine(allweddingInfo.UserId.RSVP.RSVPId);
            // List<Wedding> weddingInfo = _context.Weddings.Where(t => t.UserId == userInfo).OrderByDescending(t => t.created_at).ToList();
            // List<Wedding> allweddingInfo = _context.Weddings.OrderByDescending(t => t.created_at).ToList();
            // System.Console.WriteLine("++++++in success" + allweddingInfo);

            ViewBag.WeddingInfo = allweddingInfo;
                    

            return View("success");
        }
        [HttpGet]
        [Route("OneWedding/{Weddingid}")]
        public IActionResult OneWedding(int Weddingid) // This Method shows you the details of a specific wedding, this Method takes in 1 parameter
        {
            Wedding oneWedding = _context.Weddings.SingleOrDefault (w => w.WeddingId == Weddingid); // Model Planner has a variable named oneWedding that contains a Query to find a wedding with a sepcific WeddingId
            ViewBag.oneWedding = oneWedding; // Containing all the results of the Query oneWedding into a ViewBag for use in the HTML
            List<Wedding> guests = _context.Weddings.Where (w => w.WeddingId == Weddingid).Include (r => r.RSVP).ThenInclude (u => u.User).ToList (); // Model Planner will return a List that has a variable named guests that contains a query to find a specific WeddingId to gain access to their Guests and User
            ViewBag.AllGuests = guests; // Containing all the results of the Query guests into a ViewBag for use in the HTML
            return View("OneWedding");
        }

        [HttpGet]
        [Route("newwedding")]
        public IActionResult NewWedding()
        {
            return View();
        }
        [HttpPost]
        [Route("createwedding")]
        public IActionResult CreateWedding(Wedding model)
        {
            int? userInfo = HttpContext.Session.GetInt32("UserId");

            if (ModelState.IsValid)
            {
                Wedding NewWedding = new Wedding
                {
                    WedderOne = model.WedderOne,
                    WedderTwo = model.WedderTwo,
                    Date = model.Date,
                    WeddingAddress = model.WeddingAddress,
                    UserId = (int)userInfo,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now

                };
                _context.Add(NewWedding);
                _context.SaveChanges();
                return RedirectToAction("Success");
            }
            return View("NewWedding");
        }

        [HttpGet]
        [Route("RSVP/{Id}")]
        public IActionResult CreateRSVP(int Id)
        {
            int? userInfo = HttpContext.Session.GetInt32("UserId");

            if (ModelState.IsValid)
            {
                RSVP NewRSVP = new RSVP
                {

                    UserId = (int)userInfo,
                    WeddingId = Id,

                };
                _context.Add(NewRSVP);
                _context.SaveChanges();
                return RedirectToAction("Success");
            }
            return View("NewWedding");
        }
        [HttpGet]
        [Route("UnRSVP/{Id}")]
        public IActionResult RemoveRSVP(int Id)
        {

            // int? userInfo = HttpContext.Session.GetInt32("UserId");
            // ViewBag.UserInfo=userInfo;
            // RSVP findR = _context.RSVPS.Where(r=> r.WeddingId ==Id).Where(u => u.UserId == userInfo).SingleOrDefault();
            RSVP GetRSVPId = _context.RSVPS.SingleOrDefault(w => w.WeddingId == Id);
            // RSVP RemoveRSVPId = _context.RSVPS.Where(r=> r.WeddingId == Id).SingleOrDefault();
            // System.Console.WriteLine("++++++++++"+ RemoveRSVPId.RSVPId);
            // System.Console.WriteLine("+++++++++++++++++"+GetRSVPId.RSVPId);

            _context.RSVPS.Remove(GetRSVPId);
            _context.SaveChanges();
            return RedirectToAction("Success");
        }
        [HttpGet]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            Wedding RetrievedWedding = _context.Weddings.SingleOrDefault(w => w.WeddingId == id);
            _context.Remove(RetrievedWedding);
            _context.SaveChanges();
            return RedirectToAction("Success");
        }
        
        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }

    }
}
