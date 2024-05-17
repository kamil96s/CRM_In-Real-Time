using AutoMapper;
using CRM.Application.Lead;
using CRM.Application.Lead.Commands.Create;
using CRM.Application.Lead.Commands.Delete;
using CRM.Application.Lead.Commands.Edit;
using CRM.Application.Lead.Queries.GetAllLeads;
using CRM.Application.Lead.Queries.GetLeadByEncodedName;
using CRM.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using CRM.Domain.Entities;
using CRM.Infrastructure.Persistence;

namespace Lead.Controllers
{
    public class LeadController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly CRMDbContext _context;
        public LeadController(IMediator mediator, IMapper mapper, CRMDbContext context)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var leads = await _mediator.Send(new GetAllLeadsQuery());
            return View(leads);
        }

        [HttpPost]
        [Route("Lead/{leadId}/UpdateProgress")]
        public async Task<IActionResult> UpdateProgress(int leadId, Slider progress)
        {
            var lead = _context.Leads.Find(leadId);
            if (lead == null) return NotFound();

            lead.Progress = progress;
            await _context.SaveChangesAsync();

            return Ok();
        }


        [Route("Lead/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var dto = await _mediator.Send(new GetLeadByEncodedNameQuery(encodedName));

            if (!dto.IsEditable)
            {
                return RedirectToAction("NoAccess", "Home");
            }

            EditLeadCommand model = _mapper.Map<EditLeadCommand>(dto);

            return View(model);
        }

        [HttpPost]
        [Route("Lead/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName, EditLeadCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]//(Roles = "Owner")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]//(Roles = "Owner")]
        public async Task<IActionResult> Create(CreateLeadCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);
            this.SetNotification("success", $"Created lead - {command.Name}");
            return RedirectToAction(nameof(Index));
        }

        [Authorize]//(Roles = "Owner")]
        [Route("Lead/{encodedName}/Lead")]
        public async Task<IActionResult> Delete(string encodedName)
        {
            var command = new DeleteLeadCommand { LeadEncodedName = encodedName };

            await _mediator.Send(command);
            this.SetNotification("info", $"Lead has been deleted");
            return RedirectToAction(nameof(Index));
        }
    }
}
