using CRM.Application.CRMService.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.LeadCall.Commands
{
    public class CreateLeadCallCommandValidator : AbstractValidator<CreateLeadCallCommand>
    {
        public CreateLeadCallCommandValidator()
        {
            RuleFor(s => s.LastCallWas).NotEmpty()
                .NotEmpty().WithMessage("This field 'Department' cannot be empty");

            RuleFor(s => s.EmployeeMail).NotEmpty().NotNull()
                .NotEmpty().WithMessage("This field 'Phone' cannot be empty");

            RuleFor(s => s.AboutCall).NotEmpty().NotNull()
                .NotEmpty().WithMessage("This field 'AboutCall' cannot be empty");

            RuleFor(s => s.LeadEncodedName).NotEmpty().NotNull();
        }
    }
}
