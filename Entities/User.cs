using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Balance { get; set; }
    }
}
