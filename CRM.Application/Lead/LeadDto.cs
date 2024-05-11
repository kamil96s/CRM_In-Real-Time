using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Lead
{
    public class LeadDto
    {
        public string Name { get; set; } = default!;
        public string? Id { get; set; }
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please enter e-mail address")]
        [EmailAddress(ErrorMessage = "This e-mail address is not valid")]
        public string? Mail { get; set; }
        public string? EncodedName { get; set; }
        public bool IsEditable { get; set; }
        public bool IsDeleteable { get; set; }
    }
}
