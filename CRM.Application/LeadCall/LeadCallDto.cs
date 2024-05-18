using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.LeadCall
{
    public class LeadCallDto
    {
        [Required(ErrorMessage = "This field 'Last call was' cannot be empty")]
        public string LastCallWas { get; set; } = default!;
        [Required(ErrorMessage = "This field 'Employee E-mail' cannot be empty")]
        public string EmployeeMail { get; set; } = default!;
        public string? EncodedName { get; set; }
        public bool IsEditable { get; set; }
    }
}
