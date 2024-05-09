using CRM.Application.CRMService.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Lead.Commands.Delete
{
    public class DeleteLeadCommandValidator : AbstractValidator<DeleteLeadCommand>
    {
        public DeleteLeadCommandValidator()
        {
            RuleFor(s => s.LeadEncodedName).NotEmpty().NotNull();
        }
    }
}
