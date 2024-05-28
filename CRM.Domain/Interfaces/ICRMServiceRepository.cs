using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Interfaces
{
    public interface ICRMServiceRepository
    {
        IEnumerable<object> Services { get; }

        Task Create(CRMService crmService);
        Task Delete(CRMService Id);
        Task Delete(int Id);
        Task<IEnumerable<CRMService>> GetAllByEncodedName(string encodedName);
        Task Remove(IEnumerable<CRMService> services);
    }
}
