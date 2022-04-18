using Entities;
using InterfacesDataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SobitsTestTaskDbContext sobitsTestTaskDbContext;

        public UserRepository(SobitsTestTaskDbContext sobitsTestTaskDbContext)
        {
            this.sobitsTestTaskDbContext = sobitsTestTaskDbContext;
        }

        public async Task<List<User>> GetListAsync()
        {
            return await sobitsTestTaskDbContext.Users.ToListAsync();
        }

        public async Task CreateAsync(User user)
        {
            await sobitsTestTaskDbContext.Users.AddAsync(user);
            await sobitsTestTaskDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            sobitsTestTaskDbContext.Dispose();
        }

        public async Task<User> GetAsync(Guid id)
        {
            return await sobitsTestTaskDbContext.Users
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetByNameAsync(string name)
        {
            return await sobitsTestTaskDbContext.Users
                .FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task RemoveAsync(Guid id)
        {
            var entityDb = await sobitsTestTaskDbContext.Users
                .FirstOrDefaultAsync(x => x.Id == id);

            sobitsTestTaskDbContext.Entry(entityDb).State = EntityState.Deleted;
            sobitsTestTaskDbContext.Remove(entityDb);
            await sobitsTestTaskDbContext.SaveChangesAsync();
        }

        public async Task<List<UserByPurchase>> GetListByPurchaseId(Guid purchaseId)
        {
            return await sobitsTestTaskDbContext.UsersByPurchases
                .Where(x => x.PurchaseId == purchaseId)
                .ToListAsync();
        }

        public async Task UpdateAsync(User user)
        {
            var entityDb = await GetAsync(user.Id);

            sobitsTestTaskDbContext.Entry(entityDb).State = EntityState.Modified;

            entityDb.Balance = user.Balance;
            entityDb.Name = user.Name;

            await sobitsTestTaskDbContext.SaveChangesAsync();
        }

        public async Task<UserByPurchase> GetByPurchaseAsync(Guid id)
        {
            return await sobitsTestTaskDbContext.UsersByPurchases
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateByPurchaseAsync(UserByPurchase userByPurchase)
        {
            var entityDb = await GetByPurchaseAsync(userByPurchase.Id);

            sobitsTestTaskDbContext.Entry(entityDb).State = EntityState.Modified;

            entityDb.Id = userByPurchase.Id;
            entityDb.Debt = userByPurchase.Debt;
            entityDb.PurchaseId = userByPurchase.PurchaseId;
            entityDb.UserName = userByPurchase.UserName;
            entityDb.UserId = userByPurchase.UserId;
            entityDb.Status = userByPurchase.Status;

            await sobitsTestTaskDbContext.SaveChangesAsync();
        }

        public async Task RemoveByPurchase(Guid id)
        {
            var entityDb = await sobitsTestTaskDbContext.UsersByPurchases
                .FirstOrDefaultAsync(x => x.Id == id);

            sobitsTestTaskDbContext.Entry(entityDb).State = EntityState.Deleted;
            sobitsTestTaskDbContext.Remove(entityDb);
            await sobitsTestTaskDbContext.SaveChangesAsync();
        }
    }
}
