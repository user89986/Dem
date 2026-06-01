using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WpfApp1.Models;

namespace WpfApp1.Data;

public partial class TestDem1Context : DbContext
{
    public TestDem1Context()
    {
    }

    public TestDem1Context(DbContextOptions<TestDem1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Creater> Creaters { get; set; }

    public virtual DbSet<DetailOrder> DetailOrders { get; set; }

    public virtual DbSet<Importer> Importers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductName> ProductNames { get; set; }

    public virtual DbSet<Pvz> Pvzs { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<StatusName> StatusNames { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=TestDem1;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A0B26781FA4");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Creater>(entity =>
        {
            entity.HasKey(e => e.CreaterId).HasName("PK__Creater__538CFE8E1E05AD1F");

            entity.ToTable("Creater");

            entity.Property(e => e.CreaterName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DetailOrder>(entity =>
        {
            entity.HasKey(e => e.DetailOrdersId).HasName("PK__DetailOr__69248F57C6C64ED9");

            entity.Property(e => e.ProductsId)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Orders).WithMany(p => p.DetailOrders)
                .HasForeignKey(d => d.OrdersId)
                .HasConstraintName("FK__DetailOrd__Order__5FB337D6");

            entity.HasOne(d => d.Products).WithMany(p => p.DetailOrders)
                .HasForeignKey(d => d.ProductsId)
                .HasConstraintName("FK__DetailOrd__Produ__60A75C0F");
        });

        modelBuilder.Entity<Importer>(entity =>
        {
            entity.HasKey(e => e.ImporterId).HasName("PK__Importer__F51655320C9036A4");

            entity.ToTable("Importer");

            entity.Property(e => e.ImporterName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrdersId).HasName("PK__Orders__630B997626AC3106");

            entity.Property(e => e.Pvzid).HasColumnName("PVZId");

            entity.HasOne(d => d.Pvz).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Pvzid)
                .HasConstraintName("FK__Orders__PVZId__5AEE82B9");

            entity.HasOne(d => d.StatusName).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusNameId)
                .HasConstraintName("FK__Orders__StatusNa__5CD6CB2B");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Orders__UserId__5BE2A6F2");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductsId).HasName("PK__Products__BB48EDE5FAFA083B");

            entity.Property(e => e.ProductsId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Image)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Info)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Products__Catego__5629CD9C");

            entity.HasOne(d => d.Creater).WithMany(p => p.Products)
                .HasForeignKey(d => d.CreaterId)
                .HasConstraintName("FK__Products__Create__5535A963");

            entity.HasOne(d => d.Importer).WithMany(p => p.Products)
                .HasForeignKey(d => d.ImporterId)
                .HasConstraintName("FK__Products__Import__5441852A");

            entity.HasOne(d => d.ProductName).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductNameId)
                .HasConstraintName("FK__Products__Produc__52593CB8");

            entity.HasOne(d => d.Unit).WithMany(p => p.Products)
                .HasForeignKey(d => d.UnitId)
                .HasConstraintName("FK__Products__UnitId__534D60F1");
        });

        modelBuilder.Entity<ProductName>(entity =>
        {
            entity.HasKey(e => e.ProductNameId).HasName("PK__ProductN__343A705CBCBBD9E2");

            entity.ToTable("ProductName");

            entity.Property(e => e.ProductType)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pvz>(entity =>
        {
            entity.HasKey(e => e.Pvzid).HasName("PK__PVZ__5957648FF310B234");

            entity.ToTable("PVZ");

            entity.Property(e => e.Pvzid).HasColumnName("PVZId");
            entity.Property(e => e.Pvzname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PVZName");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1A9F9D3C23");

            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StatusName>(entity =>
        {
            entity.HasKey(e => e.StatusNameId).HasName("PK__StatusNa__977A537C8DC08DD6");

            entity.ToTable("StatusName");

            entity.Property(e => e.StatusType)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.UnitId).HasName("PK__Unit__44F5ECB582D06FBC");

            entity.ToTable("Unit");

            entity.Property(e => e.UnitName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CDBB4D0F5");

            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SecondName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users__RoleId__440B1D61");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
