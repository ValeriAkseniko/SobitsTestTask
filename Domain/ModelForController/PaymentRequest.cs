using System;

namespace Domain.ModelForController
{
    public class PaymentRequest
    {
        public Guid PurchaseId { get; set; }

        public Guid UserId { get; set; }
    }
}
