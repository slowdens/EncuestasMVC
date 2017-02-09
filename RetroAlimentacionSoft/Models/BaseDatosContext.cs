namespace RetroAlimentacionSoft.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BaseDatosContext : DbContext
    {
        public BaseDatosContext()
            : base("name=BaseDatosContext")
        {
        }

        public virtual DbSet<Calificacion> Calificacion { get; set; }
        public virtual DbSet<cat_menu> cat_menu { get; set; }
        public virtual DbSet<Cat_roles> Cat_roles { get; set; }
        public virtual DbSet<Componentes> Componentes { get; set; }
        public virtual DbSet<Historial> Historial { get; set; }
        public virtual DbSet<menu_roles> menu_roles { get; set; }
        public virtual DbSet<Preguntas> Preguntas { get; set; }
        public virtual DbSet<Respuesta> Respuesta { get; set; }
        public virtual DbSet<Software> Software { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<UsuarioRol> UsuarioRol { get; set; }
        public virtual DbSet<ValorCalificacion> ValorCalificacion { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calificacion>()
                .Property(e => e.Nomina)
                .IsUnicode(false);

            modelBuilder.Entity<Calificacion>()
                .Property(e => e.Sigla)
                .IsUnicode(false);

            modelBuilder.Entity<cat_menu>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<cat_menu>()
                .Property(e => e.Link)
                .IsUnicode(false);

            modelBuilder.Entity<Cat_roles>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cat_roles>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Componentes>()
                .Property(e => e.Compenente)
                .IsFixedLength();

            modelBuilder.Entity<Historial>()
                .Property(e => e.Nomina)
                .IsUnicode(false);

            modelBuilder.Entity<Historial>()
                .Property(e => e.Sigla)
                .IsUnicode(false);

            modelBuilder.Entity<Historial>()
                .Property(e => e.Comentario)
                .IsUnicode(false);

            modelBuilder.Entity<Preguntas>()
                .Property(e => e.Pregunta)
                .IsUnicode(false);

            modelBuilder.Entity<Preguntas>()
                .Property(e => e.Sigla)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.Respuesta1)
                .IsUnicode(false);

            modelBuilder.Entity<Software>()
                .Property(e => e.Sigla)
                .IsUnicode(false);

            modelBuilder.Entity<Software>()
                .Property(e => e.NombreSoftware)
                .IsUnicode(false);

            modelBuilder.Entity<UsuarioRol>()
                .Property(e => e.Nomina)
                .IsUnicode(false);

            modelBuilder.Entity<ValorCalificacion>()
                .Property(e => e.Estatus)
                .IsUnicode(false);
        }
    }
}
