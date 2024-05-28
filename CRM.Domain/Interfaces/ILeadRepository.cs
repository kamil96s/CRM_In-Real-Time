using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Interfaces
{
    public interface ILeadRepository
    {
        IEnumerable<object> leads { get; }
        Task Create(Domain.Entities.Lead lead);
        Task Delete(Domain.Entities.Lead Id);
        Task Delete(int Id);
        Task<Domain.Entities.Lead?> GetByName(string name);
        Task<IEnumerable<Domain.Entities.Lead>> GetAll();
        Task<Domain.Entities.Lead> GetByEncodedName(string encodedName);
        Task<int> GetPoz3LeadsCountAsync(CancellationToken cancellationToken);
        Task Commit();
        Task Remove(IEnumerable<Domain.Entities.Lead> leads);
        Task Remove(Lead lead);
    }
}
