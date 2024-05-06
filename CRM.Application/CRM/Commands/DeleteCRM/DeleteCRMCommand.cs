using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRM.Commands.DeleteCRM
{
    public class DeleteCRMCommand : CRMDto, IRequest
    {
        public string CRMEncodedName { get; set; } = default!;
        public int Id { get; set; }
    }
}