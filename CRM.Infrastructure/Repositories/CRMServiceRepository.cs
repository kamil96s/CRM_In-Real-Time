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

        public async Task Create(CRMService crmService)
        {
            _dbContext.Services.Add(crmService);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CRMService>> GetAllByEncodedName(string encodedName)
        => await _dbContext.Services
            .Where(s => s.CRM.EncodedName == encodedName)
            .ToListAsync();
    }
}
