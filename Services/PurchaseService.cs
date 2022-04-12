using Domain.Purchase;
using Domain.User;
using Entities;
using InterfacesDataAccess.Repositories;
using InterfacesServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository purchaseRepository;
        private readonly IUserRepository userRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository, IUserRepository userRepository)
        {
            this.purchaseRepository = purchaseRepository;
            this.userRepository = userRepository;
        }

        public async Task CreatePurchaseAsync(PurchaseCreateRequest purchase)
        {
            var buyerEntity = await userRepository.GetByNameAsync(purchase.Buyer);
            var usersEntity = await userRepository.GetListAsync();
            usersEntity.Remove(buyerEntity);
            Purchase entity = new Purchase()
            {
                Id = Guid.NewGuid(),
                Sum = purchase.Sum,
                Buyer = purchase.Buyer,
                Title = purchase.Title,
                Users = usersEntity
            };
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<List<PurchaseView>> GetListPurchaseAsync()
        {
            var entitiesDb = await purchaseRepository.GetListAsync();
            return entitiesDb.Select(x => new PurchaseView 
            { 
                Buyer = x.Buyer, 
                Title = x.Title 
            }).ToList();
        }

        public async Task<PurchaseView> GetPurchaseAsync(Guid id)
        {
            var entityDb = await purchaseRepository.GetAsync(id);
            return new PurchaseView()
            {
                Buyer = entityDb.Buyer,
                Debt = entityDb.Sum / entityDb.Users.Count,
                Title = entityDb.Title,
                Users = entityDb.Users.Select(x=> new UserView 
                     {
                         Name = x.Name 
                     }).ToList()
            };
        }

        public async Task RemovePurchaseAsync(Guid id)
        {
            await userRepository.RemoveAsync(id);
        }
    }
}
