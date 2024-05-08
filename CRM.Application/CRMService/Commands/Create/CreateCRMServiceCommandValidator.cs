using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRMService.Commands
{
    public class CreateCRMServiceCommandValidator : AbstractValidator<CreateCRMServiceCommand>
    {
        public CreateCRMServiceCommandValidator()
        {
            RuleFor(s => s.Cost).NotEmpty()
                .NotEmpty().WithMessage("This field 'Department' cannot be empty");

            RuleFor(s => s.Description).NotEmpty().NotNull()
                .NotEmpty().WithMessage("This field 'Phone' cannot be empty");

            RuleFor(s => s.CRMEncodedName).NotEmpty().NotNull();
        }
    }
}
