using AutoMapper;
using CRM.Application.CRM.Queries.GetCRMByEncodedName;
using CRM.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRMService.Queries.GetCRMServices
{
    public class GetCRMServicesQueryHandler : IRequestHandler<GetCRMServicesQuery, IEnumerable<CRMServiceDto>>
    {
        private readonly ICRMServiceRepository _crmServiceRepository;
        private readonly IMapper _mapper;
        public GetCRMServicesQueryHandler(ICRMServiceRepository crmServiceRepository, IMapper mapper) 
        {
            _crmServiceRepository = crmServiceRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CRMServiceDto>> Handle(GetCRMServicesQuery request, CancellationToken cancellationToken)
        {
            var result = await _crmServiceRepository.GetAllByEncodedName(request.EncodedName);

            var dtos = _mapper.Map<IEnumerable<CRMServiceDto>>(result);

            return dtos;
        }
    }
}
