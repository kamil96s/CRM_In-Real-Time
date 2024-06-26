﻿using AutoMapper;
using CRM.Application.Lead.Commands.Create;
using CRM.Application.Lead.Commands.Delete;
using CRM.Application.Lead.Commands.Edit;
using CRM.Application.Lead.Queries.GetAllLeads;
using CRM.Application.Lead.Queries.GetLeadByEncodedName;
using CRM.Application.LeadCall.Commands;
using CRM.Application.LeadCall.Queries.GetLeadCalls;
using CRM.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CRM.Domain.Entities;
using CRM.Infrastructure.Persistence;
using CRM.Application.Lead.Queries.GetPoz3LeadsCount;

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

        [HttpGet]
        [Route("Lead/Poz3Count")]
        public async Task<IActionResult> GetPoz3LeadsCount()
        {
            var count = await _mediator.Send(new GetPoz3LeadsCountQuery());
            return Ok(count);
        }

        [Route("Lead/{encodedName}/Info")]
        public async Task<IActionResult> Info(string encodedName)
        {
            var singleLead = await _mediator.Send(new GetLeadByEncodedNameQuery(encodedName));
            var leadList = await _mediator.Send(new GetAllLeadsQuery());

            var sliderInfo = new CRM.Models.Slider_Info
            {
                Info = singleLead,
                Slider = leadList
            };
            return View(sliderInfo);
        }

        [HttpPost]
        [Route("Lead/{leadId}/UpdateProgress")]
        public async Task<IActionResult> UpdateProgress([FromRoute] int leadId, [FromQuery] Slider progress)
        {
            var lead = _context.Leads.FirstOrDefault(q => q.Id == leadId);
            if (lead == null) return NotFound();

            lead.Progress = progress;
            _context.Leads.Update(lead);
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
        [HttpPost]
        [Authorize]//(Roles = "Owner")]
        [Route("Lead/LeadCall")]
        public async Task<IActionResult> CreateLeadCall(CreateLeadCallCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        [Route("Lead/{encodedName}/LeadCall")]
        public async Task<IActionResult> GetLeadCalls(string encodedName)
        {
            var data = await _mediator.Send(new GetLeadCallsQuery() { EncodedName = encodedName });
            return Ok(data);
        }

        [Authorize]//(Roles = "Owner")]
        [Route("Lead/{encodedName}/LeadCall")]
        public async Task<IActionResult> DeleteLeadCall(string encodedName)
        {
            var command = new DeleteLeadCallCommand { LeadEncodedName = encodedName };
            await _mediator.Send(command);
            return Ok();
        }
    }
}
