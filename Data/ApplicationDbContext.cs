using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PurcaseOrder.Models;

namespace PurcaseOrder.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PurcaseOrder.Models.Products> Products { get; set; }
        public DbSet<PurcaseOrder.Models.PO> PO { get; set; }
        public DbSet<PurcaseOrder.Models.Customer> Customer { get; set; }
    }
}