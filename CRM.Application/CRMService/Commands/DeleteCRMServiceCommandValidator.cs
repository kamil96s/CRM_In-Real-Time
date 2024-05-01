using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRMService.Commands
{
    public class DeleteCRMServiceCommandValidator : AbstractValidator<DeleteCRMServiceCommand>
    {
        public DeleteCRMServiceCommandValidator()
        {

        }
    }
}
