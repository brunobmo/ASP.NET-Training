using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebWorkshop1.Models
{
    public class Atleta
    {
        public string nome { get; set; }
        public DateTime data_nascimento { get; set; }
        public string genero { get; set; }

    }

    public class EquipaContext : DbContext
    {
        public DbSet<Atleta> Atleta { get; set; }
    }

}