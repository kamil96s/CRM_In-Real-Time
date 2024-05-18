 using CRM.Models;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using CRM.Application.CRM.Queries.GetAllCRMs;
using System.Diagnostics;
using CRM.Application.CRM;

namespace CRM.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var crms = await _mediator.Send(new GetAllCRMsQuery());
            var viewModel = crms.Where(c => c.IsEditable).ToList(); // Filtruj rekordy wed³ug potrzeby

            int totalNameCount = crms.Count(c => !string.IsNullOrEmpty(c.Name));
            int nameCount = viewModel.Count(c => !string.IsNullOrEmpty(c.Name)); // Liczba rekordów z w³aœciwoœci¹ Name

            var lastCreatedRecord = crms.OrderByDescending(c => c.CreatedAt).FirstOrDefault();

            ViewBag.TotalNameCount = totalNameCount;
            ViewBag.NameCount = nameCount;
            ViewBag.LastCreatedName = lastCreatedRecord?.Name;

            return View(crms);
        }

        public IActionResult NoAccess()
        {
            return View();
        }

        public IActionResult Leads()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
