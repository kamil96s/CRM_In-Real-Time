using CRM.Application.ApplicationUser;
using CRM.Application.CRMService.Commands;
using CRM.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.LeadCall.Commands.Delete
{
    internal class DeleteLeadCallCommandHandler : IRequestHandler<DeleteLeadCallCommand>
    {
        private readonly ILeadCallRepository _leadCallRepository;
        private readonly ILeadRepository _repository;
        private readonly IUserContext _userContext;

        public DeleteLeadCallCommandHandler(ILeadCallRepository CallRepository, ILeadRepository repository, IUserContext userContext)
        {
            _leadCallRepository = CallRepository;
            _repository = repository;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(DeleteLeadCallCommand request, CancellationToken cancellationToken)
        {
            var lead = await _repository.GetByEncodedName(request.LeadEncodedName!); //pobranie danego wpisu za pomocą encodedName


            var calls = await _leadCallRepository.GetAllByEncodedName(lead.EncodedName);

            await _leadCallRepository.Remove(calls);

            var user = _userContext.GetCurrentUser();                                                         //sprawdzenie czy użytkownik
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
