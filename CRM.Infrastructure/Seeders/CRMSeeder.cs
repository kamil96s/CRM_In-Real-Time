using CRM.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Seeders
{
    public class CRMSeeder
    {
        private readonly CRMDbContext _dbContext;

        public CRMSeeder(CRMDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Seed()
        {
            if(await _dbContext.Database.CanConnectAsync())
            {

            }
        }
    }
}
