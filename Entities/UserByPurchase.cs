using System;

namespace Entities
{
    public class UserByPurchase
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid PurchaseId { get; set; }

        public string UserName { get; set; }

        public bool Status { get; set; }

        public decimal Debt { get; set; }
    }
}
