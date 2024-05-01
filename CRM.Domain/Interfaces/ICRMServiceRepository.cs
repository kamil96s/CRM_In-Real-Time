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
        Task Create(CRMService crmService);
        Task Delete(CRMService crmService);
        Task<IEnumerable<CRMService>> GetAllByEncodedName(string encodedName);
    }
}
