using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PruebaTecnica4.Models
{
    public partial class estudiantesContext : DbContext
    {
        public estudiantesContext()
        {
        }

        public estudiantesContext(DbContextOptions<estudiantesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<Materium> Materia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=estudiantes;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.ToTable("estudiante");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.IdMateria).HasColumnName("idMateria");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Nota).HasColumnName("nota");

                entity.Property(e => e.Periodo).HasColumnName("periodo");

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.IdMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__estudiant__idMat__267ABA7A");
            });

            modelBuilder.Entity<Materium>(entity =>
            {
                entity.ToTable("materia");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
