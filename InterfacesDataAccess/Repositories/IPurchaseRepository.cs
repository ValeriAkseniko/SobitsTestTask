using Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterfacesDataAccess.Repositories
{
    public interface IPurchaseRepository : IDisposable
    {
        public Task CreateAsync(Purchase purchase);

        public Task RemoveAsync(Guid Id);

        public Task<List<Purchase>> GetListAsync();

        public Task<Purchase> GetAsync(Guid id);

        public Task<List<Purchase>> GetListByBuyerAsync(Guid buyerId);

    }
}
