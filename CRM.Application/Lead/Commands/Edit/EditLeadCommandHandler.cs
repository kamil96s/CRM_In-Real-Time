using CRM.Application.ApplicationUser;
using CRM.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Lead.Commands.Edit
{
    internal class EditLeadCommandHandler : IRequestHandler<EditLeadCommand>
    {
        private readonly ILeadRepository _repository;
        private readonly IUserContext _userContext;

        public EditLeadCommandHandler(ILeadRepository repository, IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(EditLeadCommand request, CancellationToken cancellationToken)
        {
            var crm = await _repository.GetByEncodedName(request.EncodedName!);

            var user = _userContext.GetCurrentUser();
            // var isEditable = user != null && (crm.CreatedById == user.Id || user.IsInRole("Moderator"));

            // if (!isEditable)
            // {
            //     return Unit.Value;
            // }

            crm.Mail = request.Mail;
            crm.Phone = request.PhoneNumber;

            await _repository.Commit();
            return Unit.Value;

        }
    }
}
