using CRM.Application.ApplicationUser;
using CRM.Domain.Entities;
using CRM.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.LeadCall.Commands
{
    public class CreateLeadCallCommandHandler : IRequestHandler<CreateLeadCallCommand>
    {
        private readonly IUserContext _userContext;
        private readonly ILeadRepository _leadRepository;
        private readonly ILeadCallRepository _leadCallRepository;

        public CreateLeadCallCommandHandler(IUserContext userContext, ILeadRepository leadRepository, ILeadCallRepository leadCallRepository)
        {
            _userContext = userContext;
            _leadRepository = leadRepository;
            _leadCallRepository = leadCallRepository;
        }

        public async Task<Unit> Handle(CreateLeadCallCommand request, CancellationToken cancellationToken)
        {
            var lead = await _leadRepository.GetByEncodedName(request.LeadEncodedName!);

            var user = _userContext.GetCurrentUser();
            // var isEditable = user != null && (crm.CreatedById == user.Id || user.IsInRole("Moderator"));

            // if (!isEditable)
            // {
            //    return Unit.Value;
            // }

            var leadCall = new Domain.Entities.LeadCall()
            {
                LastCallWas = request.LastCallWas,
                EmployeeMail = request.EmployeeMail,
                LeadId = lead.Id,
            };

            await _leadCallRepository.Create(leadCall);

            return Unit.Value;
        }
    }
}
