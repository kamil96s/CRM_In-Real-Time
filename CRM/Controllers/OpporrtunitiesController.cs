/*using Microsoft.AspNetCore.Mvc;
using CRM.Application.CRM.Queries.GetAllCRMs;
using MediatR;


namespace CRM.Controllers
{
    public class OpportunitiesController : Controller
    {
        private readonly IMediator _mediator;
        public OpportunitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var crms = await _mediator.Send(new GetAllCRMsQuery());
            return View(crms);
        }
    }
}*/