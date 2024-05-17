using AutoMapper;
using CRM.Domain.Interfaces;
using CRM.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRM.Infrastructure.Repositories;
using CRM.Application.CRM.Queries.GetAllCRMs;
using CRM.Application.CRM.Queries.GetCRMByEncodedName;
using CRM.Application.CRM;
using CRM.Application.CRM.Commands.CreateCRM;
using CRM.Application.CRM.Commands.DeleteCRM;
using CRM.Application.CRM.Commands.EditCRM;
using CRM.Application.CRMService.Commands;
using CRM.Application.CRMService.Queries.GetCRMServices;
using CRM.Extensions;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;

namespace Affiliation.Controllers
{
    public class AffiliationController : Controller
    {
        private readonly IMediator _mediator;
        public AffiliationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var crms = await _mediator.Send(new GetAllCRMsQuery());
            return View(crms);
        }
    }
}
