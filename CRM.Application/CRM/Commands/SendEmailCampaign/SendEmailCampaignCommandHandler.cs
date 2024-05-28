using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CRM.Domain.Interfaces;
using CRM.Application.Services;

namespace CRM.Application.CRM.Commands.SendEmailCampaign
{
    public class SendEmailCampaignCommandHandler : IRequestHandler<SendEmailCampaignCommand>
    {
        private readonly ICRMRepository _crmRepository;
        private readonly EmailCampaignService _emailCampaignService;

        public SendEmailCampaignCommandHandler(ICRMRepository crmRepository, EmailCampaignService emailCampaignService)
        {
            _crmRepository = crmRepository;
            _emailCampaignService = emailCampaignService;
        }

        public async Task<Unit> Handle(SendEmailCampaignCommand request, CancellationToken cancellationToken)
        {
            var emails = await _crmRepository.GetAllEmails();
            await _emailCampaignService.SendBulkEmailAsync(emails, request.Subject, request.Body);
            return Unit.Value;
        }
    }
}
