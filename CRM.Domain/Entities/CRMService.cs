using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public class CRMService
    {
        public int Id { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Cost { get; set; } = default!;

        public int CRMId { get; set; } = default!;
        public CRM CRM { get; set; } = default!;
    }
}
