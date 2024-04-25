using MediatR;

namespace CRM.Application.CRM.Queries.GetAllCRMs
{
    public class GetAllCRMsQuery : IRequest<IEnumerable<CRMDto>>
    {
    }
}
