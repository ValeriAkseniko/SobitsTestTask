namespace Domain.Purchase
{
    public class PurchaseCreateRequest
    {
        public string Title { get; set; }

        public string Buyer { get; set; }

        public decimal Sum { get; set; }
    }
}
