using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal CostPerPerson { get; set; }

        public bool PaymentStatus { get; set; }
    }
}
