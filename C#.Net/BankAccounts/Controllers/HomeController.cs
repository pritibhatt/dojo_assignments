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
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now

                    };
                    _context.Add(NewUser);
                    _context.SaveChanges();
                    int intID = (int)NewUser.UserId;
                    HttpContext.Session.SetInt32("UserId", intID);
                    return RedirectToAction("Success");
                }

            }
            ViewBag.Email = "Email is already exists in the system. Use another email or login.";
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
        [HttpPost]
        [Route("DepositWithdraw")]
        public IActionResult DepositWithdraw(Transactions trans)
        {
            int? userInfo = HttpContext.Session.GetInt32("UserId");
            User findUserInfo = _context.Users.Where(e => e.UserId == userInfo).SingleOrDefault();

            if (ModelState.IsValid)
            {



                if (trans.Amount < 0 && findUserInfo.CurrentBalance < Math.Abs(trans.Amount))
                {
                    ViewBag.Amount = "Transaction amount cannot exceed current balance";
                    List<Transactions> transactioninfo = _context.Transaction.Where(t => t.UserId == userInfo).OrderByDescending(t => t.created_at).ToList();
                    ViewBag.findUserInfo=findUserInfo;

                    ViewBag.TransactionInfo = transactioninfo;
                    
                    return View("Success");
                }
                else
                {
                    Transactions NewAmount = new Transactions
                    {
                        Amount = trans.Amount,
                        UserId = (int)userInfo,
                        created_at=DateTime.Now
                    };
                    _context.Add(NewAmount);
                    
                    findUserInfo.CurrentBalance += trans.Amount;
                    _context.SaveChanges();

                    // findUserInfo.CurrentBalance+=trans.Amount;
                    // System.Console.WriteLine("++++++++adding amount" +amount.Amount);
                    // System.Console.WriteLine(amount);
                    return RedirectToAction("Success");

                }
            }
            return RedirectToAction("Success");
        }

        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            int? userInfo = HttpContext.Session.GetInt32("UserId");
            User findUserInfo = _context.Users.Where(e => e.UserId == userInfo).SingleOrDefault();
            // System.Console.WriteLine(findUserInfo);
            ViewBag.findUserInfo = findUserInfo;
            List<Transactions> transactioninfo = _context.Transaction.Where(t => t.UserId == userInfo).OrderByDescending(t => t.created_at).ToList();
            ViewBag.TransactionInfo = transactioninfo;
            return View("success");


        }
    }
}
