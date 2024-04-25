using AutoMapper;
using CRM.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRM.Queries.GetCRMByEncodedName
{
    public class GetCRMByEncodedNameQueryHandler : IRequestHandler<GetCRMByEncodedNameQuery, CRMDto>
    {
        private readonly ICRMRepository _crmRepository;
        private readonly IMapper _mapper;

        public GetCRMByEncodedNameQueryHandler(ICRMRepository crmRepository, IMapper mapper)
        {
            _crmRepository = crmRepository;
            _mapper = mapper;
        }

        public async Task<CRMDto> Handle(GetCRMByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var crm = await _crmRepository.GetByEncodedName(request.EncodedName);

            var dto = _mapper.Map<CRMDto>(crm);

            return dto;
        }
    }
}
