using CRM.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRM.Commands.CreateCRM
{
    public class CreateCRMCommandValidator : AbstractValidator<CreateCRMCommand>
    {
        public CreateCRMCommandValidator(ICRMRepository repository)
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .MinimumLength(2).WithMessage("Name should have at least 2 characters")
                .MaximumLength(20).WithMessage("Name should have maximum of 20 characters")
                .Custom((value, context) =>
                {
                    var existingCRM = repository.GetByName(value).Result;
                    if (existingCRM != null)
                    {
                        context.AddFailure($"{value} is not unique name for company name");
                    }
                });

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Please enter description");

            RuleFor(c => c.PhoneNumber)
                .MinimumLength(8)
                .MaximumLength(12);
        }
    }
}
