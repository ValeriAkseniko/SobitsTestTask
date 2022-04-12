using Entities;
using InterfacesDataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly SobitsTestTaskDbContext sobitsTestTaskDbContext;

        public PurchaseRepository(SobitsTestTaskDbContext sobitsTestTaskDbContext)
        {
            this.sobitsTestTaskDbContext = sobitsTestTaskDbContext;
        }

        public async Task CreateAsync(Purchase purchase)
        {
            await sobitsTestTaskDbContext.Purchases.AddAsync(purchase);
            await sobitsTestTaskDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            sobitsTestTaskDbContext.Dispose();
        }

        public async Task<Purchase> GetAsync(Guid id)
        {
            return await sobitsTestTaskDbContext.Purchases
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Purchase>> GetListAsync()
        {
            return await sobitsTestTaskDbContext.Purchases.ToListAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var entityDb = await sobitsTestTaskDbContext.Purchases
                .FirstOrDefaultAsync(x => x.Id == id);

            sobitsTestTaskDbContext.Entry(entityDb).State = EntityState.Deleted;
            sobitsTestTaskDbContext.Remove(entityDb);
            await sobitsTestTaskDbContext.SaveChangesAsync();
        }
    }
}
