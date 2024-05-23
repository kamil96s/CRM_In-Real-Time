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
    public class CRMServiceRepository : ICRMServiceRepository
    {
        private readonly CRMDbContext _dbContext;
        public CRMServiceRepository(CRMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<object> Services => throw new NotImplementedException();

        public async Task Create(CRMService crmService)
        {
            _dbContext.Services.Add(crmService);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var services = _dbContext.Services.Where(s => s.Id == Id);
            _dbContext.Services.RemoveRange(services);
            await _dbContext.SaveChangesAsync();
        }
        public Task Delete(CRMService Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CRMService>> GetAllByEncodedName(string encodedName)
        => await _dbContext.Services
            .Where(s => s.CRM.EncodedName == encodedName)
            .ToListAsync();

        public async Task Remove(IEnumerable<CRMService> services)
        {
            _dbContext.Services.RemoveRange(services);
            await _dbContext.SaveChangesAsync();
        }
    }
}
