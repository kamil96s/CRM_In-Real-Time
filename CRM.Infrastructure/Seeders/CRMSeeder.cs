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
                if (!_dbContext.CRMs.Any())
                {
                    var Gerpol = new Domain.Entities.CRM()
                    {
                        Name = "Gerpol",
                        Description = "Sklep z częściami",
                        ContactDetails = new()
                        {
                            City = "Kraków",
                            Street = "Szewska 5",
                            PostalCode = "30-001",
                            PhoneNumber = "+48699222888"
                        }
                    };
                    Gerpol.EncodeName();
                    _dbContext.CRMs.Add(Gerpol);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
