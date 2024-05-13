using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Interfaces
{
    public interface ICRMRepository
    {
        IEnumerable<object> crms { get; }
        Task Create(Domain.Entities.CRM crm);
        Task Delete(Domain.Entities.CRM Id);
        Task Delete(int Id);
        Task<Domain.Entities.CRM?> GetByName(string name);
        Task<IEnumerable<Domain.Entities.CRM>> GetAll();
        Task<Domain.Entities.CRM> GetByEncodedName(string encodedName);
        Task Commit();
        Task Remove(IEnumerable<Domain.Entities.CRM> crm); // DODANE DODATKOWO
        Task Remove(Entities.CRM crm);

    }
}
