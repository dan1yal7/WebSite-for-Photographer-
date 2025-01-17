using Microsoft.AspNetCore.Mvc;

namespace PhotoWebPortfolio.Controllers
{
    public class CloudController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
