using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Workshop2019UMParte1.Models
{
    public class Task
    {
        [Key]
        public int codigo { set; get; }
        [Required]
        [StringLength(20)]
        public string nome { set; get; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime data { set; get; }
        [Required]
        public int user_id { set; get; }
        [NotMapped]
        [JsonIgnore]
        public User user { set; get; }
    }
}
