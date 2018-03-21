using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dojoSurvey.Controllers
{
    public class DojoSurveyController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("result")]
        public IActionResult Result(string name, string dojo_location, string favorite_languages, string comments)
        {
            ViewBag.name=name;
            ViewBag.dojo_location=dojo_location;
            ViewBag.favorite_languages=favorite_languages;
            ViewBag.comments=comments;
            return View();
        }

    }

}