using AutoMapper;
using CRM.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRM.Queries.GetAllCRMs
{
    internal class GetAllCRMsQueryHandler : IRequestHandler<GetAllCRMsQuery, IEnumerable<CRMDto>>
    {
        private readonly ICRMRepository _crmRepository;
        private readonly IMapper _mapper;

        public GetAllCRMsQueryHandler(ICRMRepository crmRepository, IMapper mapper)
        {
            _crmRepository = crmRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CRMDto>> Handle(GetAllCRMsQuery request, CancellationToken cancellationToken)
        {
            var crms = await _crmRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<CRMDto>>(crms);

            return dtos;
        }
    }
}
