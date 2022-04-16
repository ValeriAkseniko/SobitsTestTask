using System;

namespace Domain.User
{
    public class UserUpdateRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Balance { get; set; }
    }
}
