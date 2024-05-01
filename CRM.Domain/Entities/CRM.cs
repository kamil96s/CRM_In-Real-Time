using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public class CRM
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public CRMContactDetails ContactDetails { get; set; } = default!;

        public string? About {  get; set; }

        public string? CreatedById { get; set; }
        public IdentityUser? CreatedBy {  get; set; }

        public string EncodedName { get; private set; } = default!;

        public List<CRMService> Services { get; set; } = new();
        public string? DeletedById { get; set; }
        public IdentityUser? DeletedBy { get; set; }

        public void EncodeName() => EncodedName = Name.ToLower().Replace(" ", "-");   
    }
}
