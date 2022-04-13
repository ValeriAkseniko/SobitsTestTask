using System;
using System.Collections.Generic;

namespace Entities
{
    public class Purchase
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Buyer { get; set; }

        public Guid BuyerId { get; set; }

        public decimal Sum { get; set; }

        public List<UserByPurchase> Users { get; set; }
    }
}
