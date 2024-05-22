using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public class LeadCall
    {
        public int Id { get; set; } = default!;
        public string LastCallWas { get; set; } = default!;
        public string EmployeeMail { get; set; } = default!;
        public string AboutCall { get; set; } = default!; 

        public int LeadId { get; set; } = default!;
        public Lead Lead { get; set; } = default!;
    }
}
