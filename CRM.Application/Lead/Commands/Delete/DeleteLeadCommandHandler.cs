using CRM.Application.ApplicationUser;
using CRM.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Lead.Commands.Delete
{
    internal class DeleteLeadCommandHandler : IRequestHandler<DeleteLeadCommand>
    {
        private readonly ILeadRepository _repository;
        private readonly IUserContext _userContext;

        public DeleteLeadCommandHandler(ILeadRepository repository, IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(DeleteLeadCommand request, CancellationToken cancellationToken)
        {
            var lead = await _repository.GetByEncodedName(request.LeadEncodedName);


            await _repository.Remove(lead);

            var user = _userContext.GetCurrentUser();                                                            //sprawdzenie czy użytkownik
            // var isDeleteable = user != null && (crm.CreatedById == user.Id || user.IsInRole("Moderator"));    //jest twórcą czy moderatorem


            // if (!isDeleteable)
            // {
            //    return Unit.Value;
            // }

            // var crmService = new Domain.Entities.CRMService()
            //{

            //};
            // Wywołanie istniejącej metody w repozytorium do usunięcia usług
            // await _crmServiceRepository.Delete(crmService);

            return Unit.Value;
        }
    }
}