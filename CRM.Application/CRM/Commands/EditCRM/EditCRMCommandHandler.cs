using CRM.Application.ApplicationUser;
using CRM.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRM.Commands.EditCRM
{
    internal class EditCRMCommandHandler : IRequestHandler<EditCRMCommand>
    {
        private readonly ICRMRepository _repository;
        private readonly IUserContext _userContext;
        public EditCRMCommandHandler(ICRMRepository repository, IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(EditCRMCommand request, CancellationToken cancellationToken)
        {
            var crm = await _repository.GetByEncodedName(request.EncodedName!);

            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && (crm.CreatedById == user.Id || user.IsInRole("Moderator"));

            if (!isEditable)
            {
                return Unit.Value;
            }

            crm.Description = request.Description;
            crm.About = request.About;

            crm.ContactDetails.City = request.City;
            crm.ContactDetails.PhoneNumber = request.PhoneNumber;
            crm.ContactDetails.PostalCode = request.PostalCode;
            crm.ContactDetails.Street = request.Street;

            await _repository.Commit();
            return Unit.Value;

        }
    }
}
