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
    public class LeadCallRepository : ILeadCallRepository
    {
        private readonly CRMDbContext _dbContext;
        public LeadCallRepository(CRMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<object> Calls => throw new NotImplementedException();

        public async Task Create(LeadCall leadCall)
        {
            _dbContext.Calls.Add(leadCall);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var calls = _dbContext.Calls.Where(s => s.Id == Id);
            _dbContext.Calls.RemoveRange(calls);
            await _dbContext.SaveChangesAsync();
        }
        public Task Delete(LeadCall Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<LeadCall>> GetAllByEncodedName(string encodedName)
        => await _dbContext.Calls
            .Where(s => s.Lead.EncodedName == encodedName)
            .ToListAsync();

        public async Task Remove(IEnumerable<LeadCall> calls)
        {
            _dbContext.Calls.RemoveRange(calls);
            await _dbContext.SaveChangesAsync();
        }
    }
}
