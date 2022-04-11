namespace Domain.User
{
    public class UserCreateRequest
    {
        public string Name { get; set; }

        public decimal? CostPerPerson { get; set; }

        public bool? PaymentStatus { get; set; }

        public decimal Balance { get; set; }
    }
}
