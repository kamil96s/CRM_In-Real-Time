using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Interfaces
{
    public interface ILeadCallRepository
    {
        IEnumerable<object> Calls { get; }

        Task Create(LeadCall leadCall);
        Task Delete(LeadCall Id);
        Task Delete(int Id);
        Task<IEnumerable<LeadCall>> GetAllByEncodedName(string encodedName);
        Task Remove(IEnumerable<LeadCall> calls);
    }
}
