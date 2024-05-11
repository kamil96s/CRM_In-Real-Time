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

namespace Lead.Controllers
{
    public class LeadController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public LeadController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var leads = await _mediator.Send(new GetAllLeadsQuery());
            return View(leads);
        }

        /*        [Route("Lead/{encodedName}/Details")]
                public async Task<IActionResult> Details(string encodedName)
                {
                    var dto = await _mediator.Send(new GetLeadByEncodedNameQuery(encodedName));
                    return View(dto);
                }*/

/*        [HttpPost]
        [Route("Lead/UpdateProgress")]
        public async Task<IActionResult> Update(int leadId, int progress)
        {
            var lead = _context.Leads.Find(leadId);
            if (lead == null) return NotFound();

            lead.Progress = progress;
            await _context.SaveChangesAsync();

            return Ok();
        }*/


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

        [HttpPost]
        [Authorize]//(Roles = "Owner")]
        [Route("Lead/{encodedName}/Lead")]
        public async Task<IActionResult> Delete(string encodedName)
        {
            var command = new DeleteLeadCommand { LeadEncodedName = encodedName };

            await _mediator.Send(command);
            this.SetNotification("success", $"Deleted lead - {command.Name}");
            return RedirectToAction(nameof(Index));
        }

/*        [HttpPost]
        [Authorize]//(Roles = "Owner")]
        [Route("Lead/LeadService")]
        public async Task<IActionResult> CreateLeadService(CreateLeadServiceCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        [Route("Lead/{encodedName}/LeadService")]
        public async Task<IActionResult> GetLeadServices(string encodedName)
        {
            var data = await _mediator.Send(new GetLeadServicesQuery() { EncodedName = encodedName });
            return Ok(data);
        }

        [Authorize]//(Roles = "Owner")]
        [Route("Lead/{encodedName}/LeadService")]
        public async Task<IActionResult> DeleteLeadService(string encodedName)
        {
            var command = new DeleteLeadServiceCommand { LeadEncodedName = encodedName };
            await _mediator.Send(command);
            return Ok();
        }*/
    }
}
