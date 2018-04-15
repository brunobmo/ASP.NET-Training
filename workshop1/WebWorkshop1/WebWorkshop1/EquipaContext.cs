namespace WebWorkshop1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EquipaContext : DbContext
    {
        public EquipaContext()
            : base("name=EquipaContext")
        {
        }

        public virtual DbSet<Atleta> Atleta { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Atleta>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Atleta>()
                .Property(e => e.genero)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
