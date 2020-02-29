using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.DbModels_QuizMaker
{
    public partial class DB_Context_QuizMaker : DbContext
    {
        public DB_Context_QuizMaker()
        {
        }

        public DB_Context_QuizMaker(DbContextOptions<DB_Context_QuizMaker> options)
            : base(options)
        {
        }

        public virtual DbSet<TCuestionario> TCuestionario { get; set; }
        public virtual DbSet<TCuestionarioRegistro> TCuestionarioRegistro { get; set; }
        public virtual DbSet<TOpcion> TOpcion { get; set; }
        public virtual DbSet<TPregunta> TPregunta { get; set; }
        public virtual DbSet<TRespuesta> TRespuesta { get; set; }
        public virtual DbSet<TTipoUsuario> TTipoUsuario { get; set; }
        public virtual DbSet<TUsuario> TUsuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-706KMMK;Database=QuizMaker; persist security info=True;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TCuestionario>(entity =>
            {
                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Nombe).IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioCreaNavigation)
                    .WithMany(p => p.TCuestionario)
                    .HasForeignKey(d => d.IdUsuarioCrea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_t_Cuestionario_t_Usuario");
            });

            modelBuilder.Entity<TCuestionarioRegistro>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdCuestionario).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdCuestionarioNavigation)
                    .WithMany(p => p.TCuestionarioRegistro)
                    .HasForeignKey(d => d.IdCuestionario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_t_CuestionarioRegistro_t_Cuestionario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TCuestionarioRegistro)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_t_CuestionarioRegistro_t_Usuario");
            });

            modelBuilder.Entity<TOpcion>(entity =>
            {
                entity.Property(e => e.Etiqueta).IsUnicode(false);

                entity.Property(e => e.Texto).IsUnicode(false);

                entity.HasOne(d => d.IdPreguntaNavigation)
                    .WithMany(p => p.TOpcion)
                    .HasForeignKey(d => d.IdPregunta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_t_Opcion_t_Pregunta");
            });

            modelBuilder.Entity<TPregunta>(entity =>
            {
                entity.Property(e => e.Instrucciones).IsUnicode(false);

                entity.Property(e => e.Texto).IsUnicode(false);

                entity.HasOne(d => d.IdCuestionarioNavigation)
                    .WithMany(p => p.TPregunta)
                    .HasForeignKey(d => d.IdCuestionario)
                    .HasConstraintName("FK_t_Pregunta_t_Cuestionario");
            });

            modelBuilder.Entity<TRespuesta>(entity =>
            {
                entity.Property(e => e.Texto).IsUnicode(false);

                entity.HasOne(d => d.IdCuestionarioRegistroNavigation)
                    .WithMany(p => p.TRespuesta)
                    .HasForeignKey(d => d.IdCuestionarioRegistro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_t_Respuesta_t_CuestionarioRegistro");

                entity.HasOne(d => d.IdPreguntaNavigation)
                    .WithMany(p => p.TRespuesta)
                    .HasForeignKey(d => d.IdPregunta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_t_Respuesta_t_Pregunta");
            });

            modelBuilder.Entity<TTipoUsuario>(entity =>
            {
                entity.Property(e => e.Descriptor).IsUnicode(false);
            });

            modelBuilder.Entity<TUsuario>(entity =>
            {
                entity.Property(e => e.Apellido).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.TUsuario)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_t_Usuario_t_TipoUsuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
