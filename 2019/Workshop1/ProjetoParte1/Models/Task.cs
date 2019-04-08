using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Models
{

    public class Task
    {
        [Key]
        public int codigo { set; get; }
        [StringLength(20)]
        public string nome { set; get; }
        public DateTime data { set; get; }
        public int user_id { set; get; }
        [NotMapped]
        public User user { set; get; }
    }
}
