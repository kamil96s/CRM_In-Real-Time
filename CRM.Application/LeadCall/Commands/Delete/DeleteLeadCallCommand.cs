using CRM.Application.CRMService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.LeadCall.Commands
{
    public class DeleteLeadCallCommand : LeadCallDto, IRequest
    {
        public string LeadEncodedName { get; set; } = default!;
        public int Id { get; set; }
    }
}
