using CRM.Application.CRMService.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRM.Commands.DeleteCRM
{
    public class DeleteCRMCommandValidator : AbstractValidator<DeleteCRMCommand>
    {
        public DeleteCRMCommandValidator()
        {
            RuleFor(s => s.CRMEncodedName).NotEmpty().NotNull();
        }
    }
}
