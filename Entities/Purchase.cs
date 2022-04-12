using System;
using System.Collections.Generic;

namespace Entities
{
    public class Purchase
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Buyer { get; set; }

        public decimal Sum { get; set; }

        public List<User> Users { get; set; }
    }
}
