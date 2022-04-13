using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SobitsTestTaskDbContext : DbContext
    {
        public SobitsTestTaskDbContext(DbContextOptions<SobitsTestTaskDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<UserByPurchase> UsersByPurchases { get; set; }
    }
}
