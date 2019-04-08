using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Workshop2019UMParte1.Models
{
    public class User
    {
        [Key]
        public int codigo { set; get; }
        [Required]
        [StringLength(50)]
        public string nome { set; get; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { set; get; }

    }

    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<User> user { get; set; }
    }
}
