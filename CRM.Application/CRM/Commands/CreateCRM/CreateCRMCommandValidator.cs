using CRM.Domain.Interfaces;
using CRM.Domain.Entities;
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
                .NotEmpty().WithMessage("Please enter company name")
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

            RuleFor(c => c.Mail)
                .NotEmpty().WithMessage("Please enter e-mail address");

            RuleFor(c => c.Street)
                .NotEmpty().WithMessage("Please enter street name");

            RuleFor(c => c.City)
                .NotEmpty().WithMessage("Please enter city name");

            RuleFor(c => c.PostalCode)
                .NotEmpty().WithMessage("Please enter postal code");

            RuleFor(c => c.About)
                .NotEmpty().WithMessage("Please enter company's TIN")
                .MinimumLength(10).WithMessage("TIN should have at least 10 characters")
                .MaximumLength(12).WithMessage("TIN should have maximum of 12 characters");

            RuleFor(c => c.LegalForm)
                .NotEmpty().WithMessage("Please enter legal form of company");

            RuleFor(c => c.PhoneNumber)
                .NotEmpty().WithMessage("Please enter phone number")
                .MinimumLength(8).WithMessage("Phone number should have at least 8 characters")
                .MaximumLength(12).WithMessage("Phone number should have maximum of 12 characters");
        }
    }
}
