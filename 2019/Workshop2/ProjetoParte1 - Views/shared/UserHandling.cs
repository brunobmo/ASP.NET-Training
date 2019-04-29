using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workshop2019UMParte1.Models;

namespace Workshop2019UMParte1.shared
{
    public class UserHandling
    {
        private readonly UserContext _context;
        public UserHandling(UserContext context)
        {
            _context = context;
        }

        public User[] getUsers()
        {
            return _context.user.ToArray();
        }
    }
}
