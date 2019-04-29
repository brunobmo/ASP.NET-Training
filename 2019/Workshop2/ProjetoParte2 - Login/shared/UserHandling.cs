using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

        public bool validateUser(User user)
        {
            user.password = MyHelpers.HashPassword(user.password);
            var returnedUser = _context.user.Where(b => b.username == user.username && b.password == user.password).FirstOrDefault();

            if (returnedUser == null)
            {
                return false;
            }
            return true;
        }

        public bool registerUser(User user)
        {
            user.password = MyHelpers.HashPassword(user.password);
            _context.user.Add(user);
            _context.SaveChanges();
            return true;
        }

       


    }
}
