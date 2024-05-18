using CRM.Application.CRMService.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.LeadCall.Commands
{
    public class DeleteLeadCallCommandValidator : AbstractValidator<DeleteLeadCallCommand>
    {
        public DeleteLeadCallCommandValidator()
        {
            RuleFor(s => s.LeadEncodedName).NotEmpty().NotNull();
        }
    }
}
