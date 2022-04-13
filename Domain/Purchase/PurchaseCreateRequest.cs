using System;

namespace Domain.Purchase
{
    public class PurchaseCreateRequest
    {
        public string Title { get; set; }

        public Guid BuyerId { get; set; }

        public decimal Sum { get; set; }
    }
}
