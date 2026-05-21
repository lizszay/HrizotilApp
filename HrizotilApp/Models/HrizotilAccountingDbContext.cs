using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HrizotilApp.Models;

public partial class HrizotilAccountingDbContext : DbContext
{
    public HrizotilAccountingDbContext()
    {
    }

    public HrizotilAccountingDbContext(DbContextOptions<HrizotilAccountingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Production> Productions { get; set; }

    public virtual DbSet<Quality> Qualities { get; set; }

    public virtual DbSet<Remain> Remains { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Shipment> Shipments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=hrizotil_accounting_db;Username=postgres;Password=1111");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("groups_pkey");

            entity.ToTable("groups");

            entity.HasIndex(e => e.GroupName, "groups_group_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GroupName).HasColumnName("group_name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("products_pkey");

            entity.ToTable("products");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BulkDensityTarget).HasColumnName("bulk_density_target");
            entity.Property(e => e.IdGroup).HasColumnName("id_group");
            entity.Property(e => e.NormDustMax).HasColumnName("norm_dust_max");
            entity.Property(e => e.NormPk075mmMax).HasColumnName("norm_pk_075mm_max");
            entity.Property(e => e.NormSieve135mmMin).HasColumnName("norm_sieve_135mm_min");

            entity.HasOne(d => d.IdGroupNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdGroup)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("products_id_group_fkey");
        });

        modelBuilder.Entity<Production>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("productions_pkey");

            entity.ToTable("productions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateProduction).HasColumnName("date_production");
            entity.Property(e => e.FactQuantity)
                .HasPrecision(8, 1)
                .HasColumnName("fact_quantity");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.PlanQuantity).HasColumnName("plan_quantity");
            entity.Property(e => e.Shift).HasColumnName("shift");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Productions)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("productions_id_product_fkey");
        });

        modelBuilder.Entity<Quality>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("qualities_pkey");

            entity.ToTable("qualities");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateQuality).HasColumnName("date_quality");
            entity.Property(e => e.Dust).HasColumnName("dust");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.Pk075mm).HasColumnName("pk_075mm");
            entity.Property(e => e.Sieve135mm).HasColumnName("sieve_135mm");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Qualities)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("qualities_id_product_fkey");
        });

        modelBuilder.Entity<Remain>(entity =>
        {
            entity.HasKey(e => new { e.IdWarehouse, e.IdProduct, e.DateStock }).HasName("remains_pkey");

            entity.ToTable("remains");

            entity.Property(e => e.IdWarehouse).HasColumnName("id_warehouse");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.DateStock).HasColumnName("date_stock");
            entity.Property(e => e.Quantity)
                .HasPrecision(8, 1)
                .HasColumnName("quantity");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Remains)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("remains_id_product_fkey");

            entity.HasOne(d => d.IdWarehouseNavigation).WithMany(p => p.Remains)
                .HasForeignKey(d => d.IdWarehouse)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("remains_id_warehouse_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.HasIndex(e => e.RoleName, "roles_role_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RoleName).HasColumnName("role_name");
        });

        modelBuilder.Entity<Shipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("shipments_pkey");

            entity.ToTable("shipments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateShipment).HasColumnName("date_shipment");
            entity.Property(e => e.IdFromWarehouse).HasColumnName("id_from_warehouse");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.IdToWarehouse).HasColumnName("id_to_warehouse");
            entity.Property(e => e.Quantity)
                .HasPrecision(8, 1)
                .HasColumnName("quantity");

            entity.HasOne(d => d.IdFromWarehouseNavigation).WithMany(p => p.ShipmentIdFromWarehouseNavigations)
                .HasForeignKey(d => d.IdFromWarehouse)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("shipments_id_from_warehouse_fkey");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Shipments)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("shipments_id_product_fkey");

            entity.HasOne(d => d.IdToWarehouseNavigation).WithMany(p => p.ShipmentIdToWarehouseNavigations)
                .HasForeignKey(d => d.IdToWarehouse)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("shipments_id_to_warehouse_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Login, "users_login_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FullName).HasColumnName("full_name");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.Password).HasColumnName("password");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("users_id_role_fkey");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("warehouses_pkey");

            entity.ToTable("warehouses");

            entity.HasIndex(e => e.WarehouseName, "warehouses_warehouse_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.WarehouseName).HasColumnName("warehouse_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
