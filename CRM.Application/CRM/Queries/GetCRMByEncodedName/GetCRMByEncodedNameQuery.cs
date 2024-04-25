using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRM.Queries.GetCRMByEncodedName
{
    public class GetCRMByEncodedNameQuery : IRequest<CRMDto>
    {
        public string EncodedName { get; set; }
        public GetCRMByEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
