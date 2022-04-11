using Entities;
using InterfacesDataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
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

        public async Task<User> GetAsync(string userName)
        {
            return await sobitsTestTaskDbContext.Users
                .FirstOrDefaultAsync(x => x.Name == userName);
        }

        public async Task RemoveAsync(string userName)
        {
            var entityDb = await sobitsTestTaskDbContext.Users
                .FirstOrDefaultAsync(x => x.Name == userName);

            sobitsTestTaskDbContext.Entry(entityDb).State = EntityState.Deleted;
            sobitsTestTaskDbContext.Remove(entityDb);
            await sobitsTestTaskDbContext.SaveChangesAsync();
        }
    }
}
