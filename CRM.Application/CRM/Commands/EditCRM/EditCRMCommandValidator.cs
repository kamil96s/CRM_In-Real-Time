﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRM.Commands.EditCRM
{
    public class EditCRMCommandValidator : AbstractValidator<EditCRMCommand>
    {
        public EditCRMCommandValidator() 
        {
            RuleFor(c => c.Mail)
                .NotEmpty().WithMessage("Please enter e-mail address");

            RuleFor(c => c.PhoneNumber)
                .MinimumLength(8)
                .MaximumLength(12);
        }
    }
}
