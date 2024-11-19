using ORT_PNT1_Proyecto_2022_2C_I_Foro.Models;
using Microsoft.EntityFrameworkCore;

namespace ORT_PNT1_Proyecto_2022_2C_I_Foro.Data
{
    public class ForoContext : DbContext
    {
        public ForoContext(DbContextOptions<ForoContext> options) : base(options)
        {

        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Miembro> Miembros { get; set; }
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<Respuesta> Respuestas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-I1N0Q2M;Database=ForoDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Pregunta>().ToTable(nameof(Pregunta))
                .HasMany(p => p.Categorias)
                .WithMany(c => c.Preguntas);
                

            modelBuilder.Entity<Respuesta>()
                .HasOne(r => r.Pregunta)
                .WithMany(p => p.Respuestas)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Respuesta>()
               .HasOne(r => r.Miembro)
               .WithMany(m => m.Respuestas)
               .OnDelete(DeleteBehavior.NoAction);

            /*
                base.OnModelCreating(modelBuilder);


                modelBuilder.Entity<MiembroRespuesta>().HasKey(mp => new { mp.MiembroId, mp.RespuestaId });

                modelBuilder.Entity<MiembroRespuesta>()
                    .HasOne(mp => mp.Miembro)
                    .WithMany(m => m.RespuestasQueMeGustan)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasForeignKey(mp => mp.MiembroId)
                    ;

                modelBuilder.Entity<MiembroRespuesta>()
                    .HasOne(mp => mp.Respuesta)
                    .WithMany(p => p.MiembrosQueLikearonR)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasForeignKey(mp => mp.RespuestaId);


                modelBuilder.Entity<MiembroPregunta>().HasKey(mp => new { mp.MiembroId, mp.PreguntaId });

                modelBuilder.Entity<MiembroPregunta>()
                    .HasOne(mp => mp.Miembro)
                    .WithMany(m => m.PreguntasQueMeGustan)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasForeignKey(mp => mp.MiembroId);

                modelBuilder.Entity<MiembroPregunta>()
                    .HasOne(mp => mp.Pregunta)
                    .WithMany(p => p.MiembrosQueLikearonP)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasForeignKey(mp => mp.PreguntaId);




                modelBuilder.Entity<PreguntaCategoria>().HasKey(pc => new { pc.PreguntaId, pc.CategoriaId });

                modelBuilder.Entity<PreguntaCategoria>()
                    .HasOne(pc => pc.Pregunta)
                    .WithMany(p => p.Categorias).OnDelete(DeleteBehavior.NoAction)
                    .HasForeignKey(pc => pc.PreguntaId);

                modelBuilder.Entity<PreguntaCategoria>()
                    .HasOne(pc => pc.Categoria)
                    .WithMany(c => c.Preguntas).OnDelete(DeleteBehavior.NoAction)
                    .HasForeignKey(pc => pc.CategoriaId);



            */
        }

    }
}
