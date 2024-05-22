using System.Collections.Generic;

using CRM.Application.CRM;

using CRM.Application.Lead;

namespace CRM.Models
{
    public class Leads_Accounts
    {
        public IEnumerable<CRM.Application.Lead.LeadDto> LeadDash{ get; set; }
        public IEnumerable<CRM.Application.CRM.CRMDto> CRMDash { get; set; }
    }
}
