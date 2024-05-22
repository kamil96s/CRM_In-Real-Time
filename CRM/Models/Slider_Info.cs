using CRM.Application.Lead;

namespace CRM.Models
{
    public class Slider_Info : LeadDto
    {
        public  IEnumerable<CRM.Application.Lead.LeadDto> Slider { get; set; }
        public CRM.Application.Lead.LeadDto Info { get; set; }
    }
}
