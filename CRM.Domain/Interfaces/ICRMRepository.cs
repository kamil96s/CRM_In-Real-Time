using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Interfaces
{
    public interface ICRMRepository
    {
        Task Create(Domain.Entities.CRM crm);
        Task<Domain.Entities.CRM?> GetByName(string name);
        Task<IEnumerable<Domain.Entities.CRM>> GetAll();
        Task<Domain.Entities.CRM> GetByEncodedName(string encodedName);
        Task Commit();
    }
}
