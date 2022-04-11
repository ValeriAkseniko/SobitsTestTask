using Domain.User;
using InterfacesServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task RemoveUser(string userName)
        {
            await userService.RemoveUserAsync(userName);
        }

        [Route("user/getUser")]
        public async Task<UserView> GetUser(string userName)
        {
            return await userService.GetUserAsync(userName);
        }

        [Route("user/getListUser")]
        public async Task<List<UserView>> GetListUser()
        {
            return await userService.GetListUserAsync();
        }
    }
}
