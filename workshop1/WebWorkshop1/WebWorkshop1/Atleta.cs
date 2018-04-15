namespace WebWorkshop1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Atleta")]
    public partial class Atleta
    {
        [Key]
        public int id_atleta { get; set; }

        [StringLength(80)]
        public string nome { get; set; }

        [Column(TypeName = "date")]
        public DateTime? data_nascimento { get; set; }

        [StringLength(1)]
        public string genero { get; set; }
    }
}
