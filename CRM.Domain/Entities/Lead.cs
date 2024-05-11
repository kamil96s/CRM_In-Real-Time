using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public class Lead
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string? Mail {  get; set; }

        public string? CreatedById { get; set; }
        public IdentityUser? CreatedBy {  get; set; }

        public string EncodedName { get; private set; } = default!;

        public string? DeletedById { get; set; }
        public IdentityUser? DeletedBy { get; set; }

        public void EncodeName() => EncodedName = Name.ToLower().Replace(" ", "-");   
    }
}
