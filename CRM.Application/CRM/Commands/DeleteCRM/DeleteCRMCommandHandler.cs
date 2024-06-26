﻿using CRM.Application.ApplicationUser;
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
            var crm = await _repository.GetByEncodedName(request.CRMEncodedName!);

            await _repository.Remove(crm);

            var user = _userContext.GetCurrentUser();                                                            //sprawdzenie czy użytkownik
            // var isDeleteable = user != null && (crm.CreatedById == user.Id || user.IsInRole("Moderator"));    //jest twórcą czy moderatorem

            return Unit.Value;
        }
    }
}