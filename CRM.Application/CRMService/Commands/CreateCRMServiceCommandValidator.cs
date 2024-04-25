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
            RuleFor(s => s.Cost).NotEmpty();
            RuleFor(s => s.Description).NotEmpty().NotNull();
            RuleFor(s => s.CRMEncodedName).NotEmpty().NotNull();
        }
    }
}
