using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Lead.Commands.Delete
{
    public class DeleteLeadCommand : LeadDto, IRequest
    {
        public string LeadEncodedName { get; set; } = default!;
        public int Id { get; set; }
    }
}