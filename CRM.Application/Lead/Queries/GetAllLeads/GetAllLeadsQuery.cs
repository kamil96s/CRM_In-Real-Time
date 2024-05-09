using MediatR;

namespace CRM.Application.Lead.Queries.GetAllLeads
{
    public class GetAllLeadsQuery : IRequest<IEnumerable<LeadDto>>
    {
    }
}
