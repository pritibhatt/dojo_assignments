using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace randomPasscode.Controllers
{
    public class PasscodeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {          
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string passcode = "";
            Random rand = new Random();
            for(int i = 1; i < 15; i++)
            {
                int x = rand.Next(1,36);
                passcode += chars[x];
            }
            TempData["passcode"] = passcode;
            
            //set attempt variable to count
            int? attempt = HttpContext.Session.GetInt32("attempt");
            if(attempt == null)
            {
                HttpContext.Session.SetInt32("attempt", 1);
            }
            else
            {
                attempt += 1;
                HttpContext.Session.SetInt32("attempt", (int)attempt);
            }
        
            TempData["attempt"] = HttpContext.Session.GetInt32("attempt");
            
        
            return View();
        }

    }

}