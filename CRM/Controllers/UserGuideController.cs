using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    public class UserGuideController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
