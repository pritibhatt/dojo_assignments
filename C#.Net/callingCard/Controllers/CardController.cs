using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace callingCard.Controllers
{
    public class CardController : Controller
    {
        [HttpGet]
        [Route("{firstN}/{LastN}/{a}/{fc}")]
        public JsonResult callingCard(string firstN, string lastN, int a, string fc )
        {
            var AnonObject = new {
                                FirstName = firstN,
                                LastName = lastN,
                                Age = a,
                                favoriteColor = fc,
                            };
            return Json(AnonObject);
        }
    }
}