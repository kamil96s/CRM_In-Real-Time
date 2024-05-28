using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.CRM.Commands.SendEmailCampaign
{
    public class SendEmailCampaignCommand : IRequest
    {
        [Required(ErrorMessage = "Proszę wypełnić temat wiadomości.")]
        public string Subject { get; set; } = default!;

        [Required(ErrorMessage = "Proszę wypełnić treść wiadomości.")]

        public string Body { get; set; } = default!;
    }
}
