using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Workshop2019UMParte1.Models;
using Workshop2019UMParte1.shared;

namespace Workshop2019UMParte1.Controllers
{
    [Route("[controller]/[action]")]
    public class UserViewController : Controller
    {

        private UserHandling userHandling;
        public UserViewController(UserContext context)
        {
            //_context = context;
            userHandling = new UserHandling(context);
        }

        public IActionResult getUsers()
        {
            User[] users = userHandling.getUsers();
            return View(users);
        }
    }
}