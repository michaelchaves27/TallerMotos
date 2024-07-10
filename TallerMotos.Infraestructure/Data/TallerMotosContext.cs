using Microsoft.EntityFrameworkCore;
using TallerMotos.Infraestructure.Models;

namespace TallerMotos.Infraestructure.Data;

public partial class TallerMotosContext : DbContext
{
    public TallerMotosContext(DbContextOptions<TallerMotosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<DetalleFactura> DetalleFactura { get; set; }

    public virtual DbSet<EncargadoSucursal> EncargadoSucursal { get; set; }

    public virtual DbSet<Facturas> Facturas { get; set; }

    public virtual DbSet<Horarios> Horarios { get; set; }

    public virtual DbSet<Productos> Productos { get; set; }

    public virtual DbSet<Reservas> Reservas { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<Servicios> Servicios { get; set; }

    public virtual DbSet<Sucursales> Sucursales { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DetalleFactura>(entity =>
        {
            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.Cantidad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IDFactura).HasColumnName("IDFactura");
            entity.Property(e => e.Impuesto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SubTotal)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Total)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdfacturaNavigation).WithMany(p => p.DetalleFactura)
                .HasForeignKey(d => d.IDFactura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleFactura_Facturas");
        });

        modelBuilder.Entity<EncargadoSucursal>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.IDSucursal).HasColumnName("IDSucursal");
            entity.Property(e => e.IDUsuario).HasColumnName("IDUsuario");

            entity.HasOne(d => d.IdsucursalNavigation).WithMany()
                .HasForeignKey(d => d.IDSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EncargadoSucursal_Servicios");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany()
                .HasForeignKey(d => d.IDUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EncargadoSucursal_Usuarios");
        });

        modelBuilder.Entity<Facturas>(entity =>
        {
            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IDSucursal).HasColumnName("IDSucursal");
            entity.Property(e => e.IDUsuario).HasColumnName("IDUsuario");
            entity.Property(e => e.Impuesto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SubTotal)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Total)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdsucursalNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IDSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Facturas_Sucursales");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IDUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Facturas_Usuarios");
        });

        modelBuilder.Entity<Horarios>(entity =>
        {
            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.Dia)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Hora)
                .HasMaxLength(50)
                .IsUnicode(false);
            //entity.Property(e => e.IDSucursal).HasColumnName("IDSucursal");

            entity.HasOne(d => d.IdsucursalesNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.IDSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Horarios_Sucursales");
        });

        modelBuilder.Entity<Productos>(entity =>
        {
            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.Calificacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            // entity.Property(e => e.ID).HasColumnName("IDCategoria");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdcategoriaNavigation).WithMany(p => p.Productos)
           .HasForeignKey(d => d.IDCategoria)
            .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("FK_Productos_Categoria");
        });

        modelBuilder.Entity<Reservas>(entity =>
        {
            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IDServicio).HasColumnName("IDServicio");
            entity.Property(e => e.IDSucursal).HasColumnName("IDSucursal");
            entity.Property(e => e.IDUsuario).HasColumnName("IDUsuario");

            entity.HasOne(d => d.IdservicioNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IDServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservas_Servicios");

            entity.HasOne(d => d.IdsucursalNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IDSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservas_Sucursales");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IDUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservas_Usuarios");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Servicios>(entity =>
        {
            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.Cilindrada)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Tiempo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sucursales>(entity =>
        {
            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.HasMany(s => s.Reservas)
                .WithOne(r => r.IdsucursalNavigation)
                .HasForeignKey(r => r.IDSucursal);
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.Contrasenna).HasMaxLength(50);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IDRol).HasColumnName("IDRol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdrolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IDRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuarios_Rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
