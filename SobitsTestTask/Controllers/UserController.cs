using Domain.User;
using InterfacesServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SobitsTestTask.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("user/create")]
        public async Task CreateUser(UserCreateRequest user)
        {
            await userService.CreateUserAsync(user);
        }

        [Route("user/remove")]
        public async Task RemoveUser(Guid id)
        {
            await userService.RemoveUserAsync(id);
        }

        [Route("user/getUser")]
        public async Task<UserView> GetUser(Guid id)
        {
            return await userService.GetUserAsync(id);
        }

        [Route("user/getListUser")]
        public async Task<List<UserView>> GetListUser()
        {
            return await userService.GetListUserAsync();
        }
    }
}
