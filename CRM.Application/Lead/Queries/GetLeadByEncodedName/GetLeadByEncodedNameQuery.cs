using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Lead.Queries.GetLeadByEncodedName
{
    public class GetLeadByEncodedNameQuery : IRequest<LeadDto>
    {
        public string EncodedName { get; set; }
        public GetLeadByEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
