using Domain.User;
using System.Collections.Generic;

namespace Domain.Purchase
{
    public class PurchaseView
    {

        public string Title { get; set; }

        public string Buyer { get; set; }

        public decimal Debt { get; set; }

        public bool Status { get; set; }

        public List<UserView> Users { get; set; }
    }
}
