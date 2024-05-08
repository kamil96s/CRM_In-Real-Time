using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRMService
{
    public class CRMServiceDto
    {
        [Required(ErrorMessage = "This field 'Department' cannot be empty")]
        public string Description { get; set; } = default!;
        [Required(ErrorMessage = "This field 'Phone' cannot be empty")]
        public string Cost { get; set; } = default!;
        public string? EncodedName { get; set; }
        public bool IsEditable { get; set; }
    }
}
