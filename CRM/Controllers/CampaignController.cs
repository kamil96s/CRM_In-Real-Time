using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CRM.Application.CRM.Commands.SendEmailCampaign;
using MediatR;

namespace CRM.Controllers
{
    public class CampaignController : Controller
    {
        private readonly IMediator _mediator;

        public CampaignController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendEmailCampaign(SendEmailCampaignCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", command);
            }

            await _mediator.Send(command);
            ViewBag.Message = "Emails have been sent successfully!";
            return View("Index", command);
        }
    }
}
