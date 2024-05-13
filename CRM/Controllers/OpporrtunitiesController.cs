/*using CRM.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRM.Domain.Entities;

namespace CRM.Controllers
{
    public class OpportunitiesController : Controller
    {
        private readonly IdentityDbContext _context;

        public OpportunitiesController(IdentityDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var opportunities = await _context.Opportunity
                .Include(o => o.CreatedById)
                .Include(o => o.Names)
                .Select(o => new Opportunities
                {
                    CreatedById = o.CreatedById.Email, // Zakładając, że masz navigation property 'CreatedBy' z polem 'Email'
                    Name = o.Names.Select(c => c.Name).ToList() // Zakładając, że masz kolekcję 'Customers' powiązaną z 'Opportunities'
                })
                .ToListAsync();

            return View(opportunities);
        }
    }
}
*/