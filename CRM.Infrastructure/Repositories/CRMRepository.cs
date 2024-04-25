using CRM.Domain.Interfaces;
using CRM.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Repositories
{
    internal class CRMRepository : ICRMRepository
    {
        private readonly CRMDbContext _dbContext;

        public CRMRepository(CRMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Commit()
        => _dbContext.SaveChangesAsync();

        public async Task Create(Domain.Entities.CRM crm)
        {
            _dbContext.Add(crm);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Domain.Entities.CRM>> GetAll()
            => await _dbContext.CRMs.ToListAsync();

        public async Task<Domain.Entities.CRM> GetByEncodedName(string encodedName)
        => await _dbContext.CRMs.FirstAsync(c => c.EncodedName == encodedName);

        public Task<Domain.Entities.CRM?> GetByName(string name)
            => _dbContext.CRMs.FirstOrDefaultAsync(cw => cw.Name.ToLower() == name.ToLower());
    }
}
