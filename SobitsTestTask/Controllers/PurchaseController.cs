using Domain.Purchase;
using InterfacesServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SobitsTestTask.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly IPurchaseService purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            this.purchaseService = purchaseService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("purchase/payment")]
        public async Task PaymentForPurchase(Guid purchaseId,Guid userId)
        {
            await purchaseService.PaymentForPurchase(purchaseId, userId);
        }

        [HttpPost]
        [Route("purchase/create")]
        public async Task CreatePurchase(PurchaseCreateRequest purchase)
        {
            await purchaseService.CreatePurchaseAsync(purchase);
        }

        [HttpPost]
        [Route("purchase/remove")]
        public async Task RemovePurchase(Guid id)
        {
            await purchaseService.RemovePurchaseAsync(id);
        }

        [HttpGet]
        [Route("purchase/getPurchase")]
        public async Task<PurchaseView> GetPurchase(Guid id)
        {
            return await purchaseService.GetPurchaseAsync(id);
        }

        [HttpGet]
        [Route("purchase/getListPurchase")]
        public async Task<List<PurchaseView>> GetListPurchase()
        {
            return await purchaseService.GetListPurchaseAsync();
        }
    }
}
