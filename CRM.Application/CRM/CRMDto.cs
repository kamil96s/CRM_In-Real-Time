using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRM
{
    public class CRMDto
    {
        public string Name { get; set; } = default!;
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please enter e-mail address")]
        [EmailAddress(ErrorMessage = "This e-mail address is not valid")]
        public string? Mail { get; set; }
        public string? About { get; set; }
        public string? LegalForm { get; set; }
        public string? EncodedName { get; set; }
        public bool IsEditable { get; set; }
        public bool IsDeleteable { get; set; }
    }
}
