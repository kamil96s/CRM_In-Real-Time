using AutoMapper;
using CRM.Application.CRM;
using CRM.Application.CRM.Commands.CreateCRM;
using CRM.Application.CRM.Commands.EditCRM;
using CRM.Application.CRM.Queries.GetAllCRMs;
using CRM.Application.CRM.Queries.GetCRMByEncodedName;
using CRM.Application.CRMService.Commands;
using CRM.Application.CRMService.Queries.GetCRMServices;
using CRM.Extensions;
using CRM.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CRM.Controllers
{
    public class CRMController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CRMController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var crms = await _mediator.Send(new GetAllCRMsQuery());
            return View(crms);
        }

        [Route("CRM/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
            var dto = await _mediator.Send(new GetCRMByEncodedNameQuery(encodedName));
            return View(dto);
        }

        [Route("CRM/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var dto = await _mediator.Send(new GetCRMByEncodedNameQuery(encodedName));
            
            if(!dto.IsEditable)
            {
                return RedirectToAction("NoAccess", "Home");
            }

            EditCRMCommand model = _mapper.Map<EditCRMCommand>(dto);

            return View(model);
        }

        [HttpPost]
        [Route("CRM/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName, EditCRMCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Owner")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> Create(CreateCRMCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);

            this.SetNotification("success", $"Created customer: {command.Name}");

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize(Roles = "Owner")]
        [Route("CRM/CRMService")]
        public async Task<IActionResult> CreateCRMService(CreateCRMServiceCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet]
        [Route("CRM/{encodedName}/CRMService")]
        public async Task<IActionResult> GetCRMServices(string encodedName)
        {
            var data = await _mediator.Send(new GetCRMServicesQuery() { EncodedName = encodedName });
            return Ok(data);
        }

    }
}
