using CRM.Domain.Entities;
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
    internal class LeadRepository : ILeadRepository
    {
        private readonly CRMDbContext _dbContext;

        public LeadRepository(CRMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<object> leads => throw new NotImplementedException();

        public Task Commit()
        => _dbContext.SaveChangesAsync();

        public async Task Create(Domain.Entities.Lead lead)
        {
            _dbContext.Add(lead);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var leads = _dbContext.Leads.Where(s => s.Id == Id);
            _dbContext.RemoveRange(leads);
            await _dbContext.SaveChangesAsync();
        }
        public Task Delete(Domain.Entities.Lead Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Domain.Entities.Lead>> GetAll()
            => await _dbContext.Leads.ToListAsync();

        public async Task<Domain.Entities.Lead> GetByEncodedName(string encodedName)
        => await _dbContext.Leads.FirstAsync(c => c.EncodedName == encodedName);

        public Task<Domain.Entities.Lead?> GetByName(string name)
            => _dbContext.Leads.FirstOrDefaultAsync(cw => cw.Name.ToLower() == name.ToLower());

        public Task Remove(IEnumerable<Domain.Entities.Lead> leads)
        {
            throw new NotImplementedException();
        }
        public async Task Remove(Lead lead)
        {
            _dbContext.Remove(lead);
            await _dbContext.SaveChangesAsync(); //implementacja metody remove
        }
    }
}
