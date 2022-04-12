using Entities;
using InterfacesDataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    }
}
