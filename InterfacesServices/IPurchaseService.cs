using Domain.Purchase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterfacesServices
{
    public interface IPurchaseService : IDisposable
    {
        public Task CreatePurchaseAsync(PurchaseCreateRequest purchase);

        public Task RemovePurchaseAsync(Guid id);

        public Task<List<PurchaseView>> GetListPurchaseAsync();

        public Task<PurchaseView> GetPurchaseAsync(Guid id);
    }
}
