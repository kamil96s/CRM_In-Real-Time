using AutoMapper;
using CRM.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Lead.Queries.GetAllLeads
{
    internal class GetAllLeadsQueryHandler : IRequestHandler<GetAllLeadsQuery, IEnumerable<LeadDto>>
    {
        private readonly ILeadRepository _leadRepository;
        private readonly IMapper _mapper;

        public GetAllLeadsQueryHandler(ILeadRepository leadRepository, IMapper mapper)
        {
            _leadRepository = leadRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<LeadDto>> Handle(GetAllLeadsQuery request, CancellationToken cancellationToken)
        {
            var leads = await _leadRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<LeadDto>>(leads);

            return dtos;
        }
    }
}
