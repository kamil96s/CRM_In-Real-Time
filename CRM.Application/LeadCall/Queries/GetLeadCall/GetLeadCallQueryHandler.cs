using AutoMapper;
using CRM.Application.CRMService.Queries.GetCRMServices;
using CRM.Application.CRMService;
using CRM.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.LeadCall.Queries.GetLeadCalls
{
    public class GetLeadCallsQueryHandler : IRequestHandler<GetLeadCallsQuery, IEnumerable<LeadCallDto>>
    {
        private readonly ILeadCallRepository _leadCallRepository;
        private readonly IMapper _mapper;
        public GetLeadCallsQueryHandler(ILeadCallRepository leadCallRepository, IMapper mapper)
        {
            _leadCallRepository = leadCallRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<LeadCallDto>> Handle(GetLeadCallsQuery request, CancellationToken cancellationToken)
        {
            var result = await _leadCallRepository.GetAllByEncodedName(request.EncodedName);

            var dtos = _mapper.Map<IEnumerable<LeadCallDto>>(result);

            return dtos;
        }
    }
}
