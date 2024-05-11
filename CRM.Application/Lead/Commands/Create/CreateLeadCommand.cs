using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Lead.Commands.Create
{
    public class CreateLeadCommand : LeadDto, IRequest
    {
        public string LeadEncodedName { get; set; } = default!;
    }
}
