using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SunBaby.WebApi.Controllers
{
    [Route("[controller]")]
    public class FormController : Controller
    {
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }        
    }
}
