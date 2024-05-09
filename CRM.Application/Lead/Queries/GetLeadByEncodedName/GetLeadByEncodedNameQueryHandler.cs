using AutoMapper;
using CRM.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Lead.Queries.GetLeadByEncodedName
{
    public class GetLeadByEncodedNameQueryHandler : IRequestHandler<GetLeadByEncodedNameQuery, LeadDto>
    {
        private readonly ILeadRepository _leadRepository;
        private readonly IMapper _mapper;

        public GetLeadByEncodedNameQueryHandler(ILeadRepository leadRepository, IMapper mapper)
        {
            _leadRepository = leadRepository;
            _mapper = mapper;
        }

        public async Task<LeadDto> Handle(GetLeadByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var lead = await _leadRepository.GetByEncodedName(request.EncodedName);

            var dto = _mapper.Map<LeadDto>(lead);

            return dto;
        }
    }
}
