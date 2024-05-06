using CRM.Application.ApplicationUser;
using CRM.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRM.Commands.DeleteCRM
{
    internal class DeleteCRMCommandHandler : IRequestHandler<DeleteCRMCommand>
    {
        private readonly ICRMServiceRepository _crmServiceRepository;
        private readonly ICRMRepository _repository;
        private readonly IUserContext _userContext;

        public DeleteCRMCommandHandler(ICRMServiceRepository ServiceRepository, ICRMRepository repository, IUserContext userContext)
        {
            _crmServiceRepository = ServiceRepository;
            _repository = repository;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(DeleteCRMCommand request, CancellationToken cancellationToken)
        {
            var crm = await _repository.GetByEncodedName(request.CRMEncodedName!); //pobranie danego wpisu za pomocą encodedName

            await _repository.Remove((IEnumerable<Domain.Entities.CRM>)crm);

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