using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Lead.Commands.Edit
{
    public class EditLeadCommandValidator : AbstractValidator<EditLeadCommand>
    {
        public EditLeadCommandValidator()
        {
            RuleFor(c => c.Mail)
                .NotEmpty().WithMessage("Please enter e-mail address");

            RuleFor(c => c.PhoneNumber)
                .MinimumLength(8)
                .MaximumLength(12);
        }
    }
}
