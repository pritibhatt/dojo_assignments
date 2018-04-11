using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using BeltExamTwo.Models;
using System.Linq;

namespace BeltExamTwo.Controllers
{
    public class HomeController : Controller
    {
         private BeltExamTwoContext _context;
         public HomeController(BeltExamTwoContext context)
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
            if (ModelState.IsValid)
            {
                User findEmail = _context.Users.Where(e => e.Email == user.Email).SingleOrDefault();
                if (findEmail == null)
                {
                    //use below two lines to hash password
                    // PasswordHasher<RegisterViewModel> Hasher = new PasswordHasher<RegisterViewModel>(); // This will hash the password
                    // string hashed = Hasher.HashPassword(user, user.Password); 
                    User NewUser = new User
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Password = user.Password, //change this to hashed if using hashed password
                      

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
        public IActionResult Signin(LoginUser  LoginUser)
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
                    else
                    {
                        //use below two lines to hash password and comment out lines 96 and 97.
                        // var hasher = new PasswordHasher<User>(); // This will hash the password
                        // if(hasher.VerifyHashedPassword(findEmail, findEmail.Password, LoginUser.Password) == 0)
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
           
            // ViewBag.allIdeaInfo = allIdeaInfo;
            List<Activity> AllActivityInfo =  _context.Activities.Include(r => r.Join).ThenInclude(u=>u.User).OrderByDescending(t => t.created_at).ToList();
            ViewBag.AllActivityInfo=AllActivityInfo;
            return View("success");
        }
        [HttpGet]
        [Route("newactivity")]
        public IActionResult NewActivity()
        {
            return View();
        }
        [HttpPost]
        [Route("createactivity")]
        public IActionResult CreateActivity(Activity model)
        {
            int? userInfo = HttpContext.Session.GetInt32("UserId");

            if (ModelState.IsValid)
            {
                Activity NewActivity= new Activity
                {
                    ActivityName = model.ActivityName,
                    Duration = model.Duration,
                    Description=model.Description,
                    DescriptionTwo=model.DescriptionTwo,
                    Date = model.Date,
                    Time = model.Time,
                    UserId = (int)userInfo,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now

                };
                _context.Add(NewActivity);
                _context.SaveChanges();
                return RedirectToAction("Success");
            }
            return View("NewActivity");
        }
        [HttpGet]
        [Route("Join/{Id}")]
        public IActionResult CreateJoin(int Id)
        {
            int? userInfo = HttpContext.Session.GetInt32("UserId");

            if (ModelState.IsValid)
            {
                Join NewJoin = new Join
                {

                    UserId = (int)userInfo,
                    ActivityId = Id,

                };
                _context.Add(NewJoin);
                _context.SaveChanges();
                return RedirectToAction("success");
            }
            return View("Success");
        }
        
        [HttpGet]
        [Route("UnJoin/{Id}")]
        public IActionResult RemoveJoin(int Id)
        {

            // int? userInfo = HttpContext.Session.GetInt32("UserId");
            // ViewBag.UserInfo=userInfo;
            // RSVP findR = _context.RSVPS.Where(r=> r.WeddingId ==Id).Where(u => u.UserId == userInfo).SingleOrDefault();
            Join GetJoinId = _context.Joins.SingleOrDefault(w => w.ActivityId == Id);
            // RSVP RemoveRSVPId = _context.RSVPS.Where(r=> r.WeddingId == Id).SingleOrDefault();
            // System.Console.WriteLine("++++++++++"+ RemoveRSVPId.RSVPId);
            // System.Console.WriteLine("+++++++++++++++++"+GetRSVPId.RSVPId);

            _context.Joins.Remove(GetJoinId);
            _context.SaveChanges();
            return RedirectToAction("Success");
        }
        

        [HttpGet]
        [Route("Oneactivity/{Activityid}")]
        public IActionResult OneActivity(int Activityid) // This Method shows you the details of a specific wedding, this Method takes in 1 parameter
        {
            int? userInfo = HttpContext.Session.GetInt32("UserId");
            ViewBag.userInfo=userInfo;
            List<Activity> findIdeas = _context.Activities.Include(t => t.User).Include (r => r.Join).ToList (); // Model Planner will return a List that has a variable named guests that contains a query to find a specific WeddingId to gain access to their Guests and User
            ViewBag.findIdeas = findIdeas;
            
            
            Activity oneActivity = _context.Activities.SingleOrDefault (w => w.ActivityId == Activityid); // Model Planner has a variable named oneWedding that contains a Query to find a wedding with a sepcific WeddingId
            ViewBag.oneActivity = oneActivity; // Containing all the results of the Query oneWedding into a ViewBag for use in the HTML
            System.Console.WriteLine("+++++one idea info"+ oneActivity);
            List<Activity> Joins = _context.Activities.Where (w => w.ActivityId == Activityid).Include(r=>r.Join).ThenInclude (u => u.User).ToList (); // Model Planner will return a List that has a variable named guests that contains a query to find a specific WeddingId to gain access to their Guests and User
            ViewBag.Joins = Joins; // Containing all the results of the Query guests into a ViewBag for use in the HTML
            return View("OneActivity");
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            Activity RetrieveActivity = _context.Activities.SingleOrDefault(w => w.ActivityId == id);
            _context.Remove(RetrieveActivity);
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
