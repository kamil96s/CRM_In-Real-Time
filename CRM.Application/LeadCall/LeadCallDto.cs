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
        [RegularExpression(@"\d{2}-\d{2}-\d{4}", ErrorMessage = "Please enter the correct format dd-mm-yyyy")]
        public string LastCallWas { get; set; } = default!;
        [Required(ErrorMessage = "This field 'Employee E-mail' cannot be empty")]
        [EmailAddress(ErrorMessage = "This e-mail address is not valid")]
        public string EmployeeMail { get; set; } = default!;

        [Required(ErrorMessage = "This field 'About call' cannot be empty")]
        public string AboutCall { get; set; } = default!;
        public string? EncodedName { get; set; }
        public bool IsEditable { get; set; }
    }
}
