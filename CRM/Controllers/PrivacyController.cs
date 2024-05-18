using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    public class PrivacyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
