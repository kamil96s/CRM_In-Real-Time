using AutoMapper;
using CRM.Application.ApplicationUser;
using CRM.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRM.Commands.CreateCRM
{
    public class CreateCRMCommandHandler : IRequestHandler<CreateCRMCommand>
    {
        private readonly ICRMRepository _crmRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateCRMCommandHandler(ICRMRepository crmRepository, IMapper mapper, IUserContext userContext)
        {
            _crmRepository = crmRepository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(CreateCRMCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();
            if (currentUser == null || !currentUser.IsInRole("Owner"))
            {
                return Unit.Value;
            }
            var crm = _mapper.Map<Domain.Entities.CRM>(request);
            crm.EncodeName();

            crm.CreatedById = currentUser.Id;

            await _crmRepository.Create(crm);

            return Unit.Value;
        }
    }
}
