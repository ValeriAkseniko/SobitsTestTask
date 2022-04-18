using Domain.User;
using System;
using System.Collections.Generic;

namespace Domain.Purchase
{
    public class PurchaseView
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public Guid BuyerId { get; set; }

        public string Buyer { get; set; }
        

        public decimal Debt { get; set; }

        public bool Status { get; set; }

        public List<UserByPurchaseView> Users { get; set; }
    }
}
