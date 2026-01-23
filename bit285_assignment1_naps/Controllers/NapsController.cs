using Microsoft.AspNetCore.Mvc;

namespace bit285_assignment1_naps.Controllers
{
    public class NapsController : Controller
    {
        [HttpGet]
        public IActionResult AccountInfo()
        {
            return new ContentResult { Content = "Hello", ContentType = "text/html" };
        }

        [HttpPost]
        public IActionResult AccountInfo(Microsoft.AspNetCore.Http.IFormCollection form)
        {
            // TODO: accept a strongly-typed model and process form submission
            return new ContentResult { Content = "Posted", ContentType = "text/html" };
        }
    }
}
