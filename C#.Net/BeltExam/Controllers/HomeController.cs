using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using BeltExam.Models;
using System.Linq;
namespace BeltExam.Controllers
{
    public class HomeController : Controller
    {
         private BeltExamContext _context;

        public HomeController(BeltExamContext context)
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
                    //use below two lines to hash password
                    // PasswordHasher<RegisterViewModel> Hasher = new PasswordHasher<RegisterViewModel>(); // This will hash the password
                    // string hashed = Hasher.HashPassword(user, user.Password); 
                    User NewUser = new User
                    {
                        Name = user.Name,
                        Alias = user.Alias,
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
            List<Idea> allIdeaInfo = _context.Ideas.Include(r => r.User).ToList();
            ViewBag.allIdeaInfo = allIdeaInfo;
            List<Idea> AllLikes =  _context.Ideas.Include(r => r.Like).ThenInclude(u=>u.User).ToList();

            return View("success");
        }
        [HttpGet]
        [Route("UserInfo/{Ideaid}")]

        public IActionResult UserInfo(int Ideaid)
        {
            List<User> users = _context.Users.ToList (); // Model Planner will return a List that has a variable named guests that contains a query to find a specific WeddingId to gain access to their Guests and User
           
            ViewBag.users = users;
            Idea oneIdeas = _context.Ideas.SingleOrDefault (w => w.IdeaId == Ideaid); // Model Planner has a variable named oneWedding that contains a Query to find a wedding with a sepcific WeddingId
            ViewBag.oneIdeas = oneIdeas; // Containing all the results of the Query oneWedding into a ViewBag for use in the HTML
            System.Console.WriteLine("+++++one idea info"+ oneIdeas);
            List<Idea> secondlikes = _context.Ideas.Where (w => w.IdeaId == Ideaid).Include (u => u.User).ToList (); // Model Planner will return a List that has a variable named guests that contains a query to find a specific WeddingId to gain access to their Guests and User
            ViewBag.SecondAllLikes = secondlikes;
           
           
            List<Idea> Countlikes = _context.Ideas.Include(t => t.User).Include (r => r.Like).ToList (); // Model Planner will return a List that has a variable named guests that contains a query to find a specific WeddingId to gain access to their Guests and User
            ViewBag.Countlikes = Countlikes;
            return View("UserInfo");
        }
        [HttpGet]
        [Route("OneIdea/{Ideaid}")]
        public IActionResult OneIdea(int Ideaid) // This Method shows you the details of a specific wedding, this Method takes in 1 parameter
        {
            
            List<Idea> findIdeas = _context.Ideas.Include(t => t.User).Include (r => r.Like).ToList (); // Model Planner will return a List that has a variable named guests that contains a query to find a specific WeddingId to gain access to their Guests and User
            ViewBag.findIdeas = findIdeas;
            
            
            Idea oneIdea = _context.Ideas.SingleOrDefault (w => w.IdeaId == Ideaid); // Model Planner has a variable named oneWedding that contains a Query to find a wedding with a sepcific WeddingId
            ViewBag.oneIdea = oneIdea; // Containing all the results of the Query oneWedding into a ViewBag for use in the HTML
            System.Console.WriteLine("+++++one idea info"+ oneIdea);
            List<Idea> likes = _context.Ideas.Where (w => w.IdeaId == Ideaid).Include (r => r.Like).ThenInclude (u => u.User).ToList (); // Model Planner will return a List that has a variable named guests that contains a query to find a specific WeddingId to gain access to their Guests and User
            ViewBag.AllLikes = likes; // Containing all the results of the Query guests into a ViewBag for use in the HTML
            return View("OneIdea");
        }

        [HttpPost]
        [Route("createidea")]
        public IActionResult CreateIdea(Idea model)
        {
            int? userInfo = HttpContext.Session.GetInt32("UserId");

            if (ModelState.IsValid)
            {
                Idea NewStringIdea = new Idea
                {
                    NewIdea = model.NewIdea,
                    UserId = (int)userInfo,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now

                };
                _context.Add(NewStringIdea);
                _context.SaveChanges();
                return RedirectToAction("Success");
            }
            return View("Success");
        }

        [HttpGet]
        [Route("Like/{Id}")]
        public IActionResult CreateRSVP(int Id)
        {
            int? userInfo = HttpContext.Session.GetInt32("UserId");

            if (ModelState.IsValid)
            {
                Like NewLike = new Like
                {

                    UserId = (int)userInfo,
                    IdeaId = Id,

                };
                _context.Add(NewLike);
                _context.SaveChanges();
                return RedirectToAction("Success");
            }
            return View("Success");
        }
        
        [HttpGet]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            Idea RetrieveIdea = _context.Ideas.SingleOrDefault(w => w.IdeaId == id);
            _context.Remove(RetrieveIdea);
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
