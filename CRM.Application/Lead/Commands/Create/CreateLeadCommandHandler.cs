using AutoMapper;
using CRM.Application.ApplicationUser;
using CRM.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Lead.Commands.Create
{
    public class CreateLeadCommandHandler : IRequestHandler<CreateLeadCommand>
    {
        private readonly ILeadRepository _leadRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateLeadCommandHandler(ILeadRepository leadRepository, IMapper mapper, IUserContext userContext)
        {
            _leadRepository = leadRepository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(CreateLeadCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();
            // if (currentUser == null || !currentUser.IsInRole("Owner"))
            // {
            //    return Unit.Value;
            // }
            var lead = _mapper.Map<Domain.Entities.Lead>(request);
            lead.EncodeName();

            lead.CreatedById = currentUser.Id; // crm.CreatedById = currentUser.Id; _userContext.GetCurrentUser().Id;

            await _leadRepository.Create(lead);

            return Unit.Value;
        }
    }
}
