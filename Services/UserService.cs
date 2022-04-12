﻿using Domain.User;
using Entities;
using InterfacesDataAccess.Repositories;
using InterfacesServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task CreateUserAsync(UserCreateRequest userRequest)
        {
            User user = new User()
            {
                Id = Guid.NewGuid(),
                Name = userRequest.Name,
                Balance = userRequest.Balance
            };
            await userRepository.CreateAsync(user);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<UserView> GetUserAsync(string userName)
        {
            var user = await userRepository.GetAsync(userName);
            return new UserView
            {
                Name = user.Name,
                Balance = user.Balance
            };
        }

        public async Task<List<UserView>> GetListUserAsync()
        {
            var users = await userRepository.GetListAsync();
            return users.Select(x => new UserView
            {
                Name = x.Name,
                Balance = x.Balance
            }).ToList();
        }

        public async Task RemoveUserAsync(string userName)
        {
            await userRepository.RemoveAsync(userName);
        }
    }
}