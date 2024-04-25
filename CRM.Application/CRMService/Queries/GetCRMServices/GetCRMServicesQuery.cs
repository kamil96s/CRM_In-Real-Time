using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRMService.Queries.GetCRMServices
{
    public class GetCRMServicesQuery : IRequest<IEnumerable<CRMServiceDto>>
    {
        public string EncodedName { get; set; } = default!;
    }
}
