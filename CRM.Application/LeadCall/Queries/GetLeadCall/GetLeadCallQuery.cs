using CRM.Application.CRMService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.LeadCall.Queries.GetLeadCalls
{
    public class GetLeadCallsQuery : IRequest<IEnumerable<LeadCallDto>>
    {
        public string EncodedName { get; set; } = default!;
    }
}
