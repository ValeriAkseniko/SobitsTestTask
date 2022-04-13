using Domain.Purchase;
using Domain.User;
using Entities;
using InterfacesDataAccess.Repositories;
using InterfacesServices;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var buyerEntity = await userRepository.GetAsync(purchase.BuyerId);
            var usersEntity = await userRepository.GetListAsync();
            usersEntity.Remove(buyerEntity);
            var debt = purchase.Sum / usersEntity.Count;
            var id = Guid.NewGuid();
            Purchase entity = new Purchase()
            {
                Id = id,
                Sum = purchase.Sum,
                Buyer = buyerEntity.Name,
                Title = purchase.Title,
                Users = usersEntity.Select(x => new UserByPurchase()
                {
                    UserName = x.Name,
                    Debt = debt,
                    PurchaseId = id,
                    Id = Guid.NewGuid(),
                    Status = false
                }).ToList(),
                BuyerId = purchase.BuyerId
            };
            await purchaseRepository.CreateAsync(entity);
        }

        public void Dispose()
        {
            purchaseRepository.Dispose();
        }

        public async Task<List<PurchaseView>> GetListPurchaseAsync()
        {
            var entitiesDb = await purchaseRepository.GetListAsync();
            return entitiesDb.Select(x => new PurchaseView
            {
                Buyer = x.Buyer,
                Title = x.Title,
                Users = x.Users.Select(z => new UserByPurchaseView() 
                { 
                    UserName = z.UserName,
                    Debt = z.Debt,
                    Status = z.Status 
                }).ToList()
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
                Users = entityDb.Users.Select(z => new UserByPurchaseView()
                {
                    UserName = z.UserName,
                    Debt = z.Debt,
                    Status = z.Status
                }).ToList()
            };
        }

        public async Task RemovePurchaseAsync(Guid id)
        {
            await userRepository.RemoveAsync(id);
        }
    }
}
