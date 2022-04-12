﻿using Domain.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterfacesServices
{
    public interface IUserService : IDisposable
    {
        public Task CreateUserAsync(UserCreateRequest user);

        public Task RemoveUserAsync(string userName);

        public Task<List<UserView>> GetListUserAsync();

        public Task<UserView> GetUserAsync(string userName);
    }
}