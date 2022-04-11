using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        [Key]
        public string Name { get; set; }

        public decimal ?CostPerPerson { get; set; }

        public bool ?PaymentStatus { get; set; }
    }
}
