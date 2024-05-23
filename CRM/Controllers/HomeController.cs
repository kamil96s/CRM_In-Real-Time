using CRM.Models;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using CRM.Application.CRM.Queries.GetAllCRMs;
using System.Diagnostics;
using CRM.Application.CRM;
using CRM.Application.Lead.Queries.GetAllLeads;
using CRM.Application.Lead.Queries.GetPoz3LeadsCount;

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
            var leads = await _mediator.Send(new GetAllLeadsQuery());

            var viewModel = new Leads_Accounts
            {
                CRMDash = crms,
                LeadDash = leads
            };

            int totalNameCount = crms.Count(c => !string.IsNullOrEmpty(c.Name));
            int nameCount = crms.Where(c => c.IsEditable).Count(c => !string.IsNullOrEmpty(c.Name));
            var lastCreatedRecord = crms.OrderByDescending(c => c.CreatedAt).FirstOrDefault();

            int totalLeadCount = leads.Count(c => !string.IsNullOrEmpty(c.Name));
            int leadCount = leads.Where(c => c.IsEditable).Count(c => !string.IsNullOrEmpty(c.Name));
            var lastCreatedLead = leads.OrderByDescending(c => c.CreatedAt).FirstOrDefault();

            ViewBag.TotalNameCount = totalNameCount;
            ViewBag.NameCount = nameCount;
            ViewBag.LastCreatedName = lastCreatedRecord?.Name;

            ViewBag.TotalLeadCount = totalLeadCount;
            ViewBag.LeadCount = leadCount;
            ViewBag.LastCreatedLead = lastCreatedLead?.Name;

            return View(viewModel);
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
