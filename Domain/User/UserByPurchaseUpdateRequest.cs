using System;

namespace Domain.User
{
    public class UserByPurchaseUpdateRequest
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid PurchaseId { get; set; }

        public string UserName { get; set; }

        public bool Status { get; set; }

        public decimal Debt { get; set; }
    }
}
