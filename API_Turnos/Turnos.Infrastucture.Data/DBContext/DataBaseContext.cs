using Microsoft.EntityFrameworkCore;
using Turnos.Domain.Model;

namespace Turnos.Infrastucture.Data.DBContext;

public partial class DataBaseContext : DbContext
{
    public DataBaseContext()
    {
    }

    public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comercio> Comercios { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<Turno> Turnos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Turnos;TrustServerCertificate=true;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comercio>(entity =>
        {
            entity.HasKey(e => e.IdComercio);

            entity.ToTable("comercios");

            entity.Property(e => e.IdComercio)
                .ValueGeneratedNever()
                .HasColumnName("id_comercio");
            entity.Property(e => e.AforoMaximo).HasColumnName("aforo_maximo");
            entity.Property(e => e.NomComercio)
                .HasMaxLength(50)
                .HasColumnName("nom_comercio");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio);

            entity.ToTable("servicios");

            entity.Property(e => e.IdServicio)
                .ValueGeneratedNever()
                .HasColumnName("id_servicio");
            entity.Property(e => e.Duracion).HasColumnName("duracion");
            entity.Property(e => e.HoraApertura)
                .HasColumnType("datetime")
                .HasColumnName("hora_apertura");
            entity.Property(e => e.HoraCierre)
                .HasColumnType("datetime")
                .HasColumnName("hora_cierre");
            entity.Property(e => e.IdComercio).HasColumnName("id_comercio");
            entity.Property(e => e.NomServicio)
                .HasMaxLength(50)
                .HasColumnName("nom_servicio");

            entity.HasOne(d => d.IdComercioNavigation).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.IdComercio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_servicios_comercios");
        });

        modelBuilder.Entity<Turno>(entity =>
        {
            entity.HasKey(e => e.IdTurno);

            entity.ToTable("turnos");

            entity.Property(e => e.IdTurno)
                .ValueGeneratedNever()
                .HasColumnName("id_turno");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaTurno)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("fecha_turno");
            entity.Property(e => e.HoraFin)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("hora_fin");
            entity.Property(e => e.HoraInicio)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("hora_inicio");
            entity.Property(e => e.IdServicio).HasColumnName("id_servicio");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.Turnos)
                .HasForeignKey(d => d.IdServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_turnos_servicios");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
