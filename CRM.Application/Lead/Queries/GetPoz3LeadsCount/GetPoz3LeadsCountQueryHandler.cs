using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CRM.Domain.Interfaces;

namespace CRM.Application.Lead.Queries.GetPoz3LeadsCount
{
    public class GetPoz3LeadsCountQueryHandler : IRequestHandler<GetPoz3LeadsCountQuery, int>
    {
        private readonly ILeadRepository _leadRepository;

        public GetPoz3LeadsCountQueryHandler(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        public async Task<int> Handle(GetPoz3LeadsCountQuery request, CancellationToken cancellationToken)
        {
            return await _leadRepository.GetPoz3LeadsCountAsync(cancellationToken);
        }
    }
}