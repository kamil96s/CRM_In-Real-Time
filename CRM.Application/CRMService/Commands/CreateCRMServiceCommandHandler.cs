using CRM.Application.ApplicationUser;
using CRM.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRMService.Commands
{
    public class CreateCRMServiceCommandHandler : IRequestHandler<CreateCRMServiceCommand>
    {
        private readonly IUserContext _userContext;
        private readonly ICRMRepository _crmRepository;
        private readonly ICRMServiceRepository _crmServiceRepository;

        public CreateCRMServiceCommandHandler(IUserContext userContext, ICRMRepository crmRepository, ICRMServiceRepository crmServiceRepository)
        {
            _userContext = userContext;
            _crmRepository = crmRepository;
            _crmServiceRepository = crmServiceRepository;
        }

        public async Task<Unit> Handle(CreateCRMServiceCommand request, CancellationToken cancellationToken)
        {
            var crm = await _crmRepository.GetByEncodedName(request.CRMEncodedName!);

            var user = _userContext.GetCurrentUser();
            // var isEditable = user != null && (crm.CreatedById == user.Id || user.IsInRole("Moderator"));

            // if (!isEditable)
            // {
            //    return Unit.Value;
            // }

            var crmService = new Domain.Entities.CRMService()
            {
                Cost = request.Cost,
                Description = request.Description,
                CRMId = crm.Id,
            };

            await _crmServiceRepository.Create(crmService);

            return Unit.Value;
        }
    }
}
