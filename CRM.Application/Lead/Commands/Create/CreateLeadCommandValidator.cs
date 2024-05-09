using CRM.Domain.Interfaces;
using CRM.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Lead.Commands.Create
{
    public class CreateLeadCommandValidator : AbstractValidator<CreateLeadCommand>
    {
        public CreateLeadCommandValidator(ILeadRepository repository)
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please enter company name")
                .MinimumLength(2).WithMessage("Name should have at least 2 characters")
                .MaximumLength(20).WithMessage("Name should have maximum of 20 characters")
                .Custom((value, context) =>
                {
                    var existingLead = repository.GetByName(value).Result;
                    if (existingLead != null)
                    {
                        context.AddFailure($"{value} is not unique name for company name");
                    }
                });

            RuleFor(c => c.PhoneNumber)
                .NotEmpty().WithMessage("Please enter phone number")
                .MinimumLength(8).WithMessage("Phone number should have at least 8 characters")
                .MaximumLength(12).WithMessage("Phone number should have maximum of 12 characters");

            RuleFor(c => c.Mail)
                .NotEmpty().WithMessage("Please enter E-Mail");

        }
    }
}
