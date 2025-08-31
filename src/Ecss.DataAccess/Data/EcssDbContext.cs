using Ecss.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecss.DataAccess.Data;

public partial class EcssDbContext : DbContext
{
    public EcssDbContext()
    {
    }

    public EcssDbContext(DbContextOptions<EcssDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdminAction> AdminActions { get; set; }

    public virtual DbSet<Advert> Adverts { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Component> Components { get; set; }

    public virtual DbSet<CreditCard> CreditCards { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductComponent> ProductComponents { get; set; }

    public virtual DbSet<ProductDesign> ProductDesigns { get; set; }

    public virtual DbSet<ProductDesignOption> ProductDesignOptions { get; set; }

    public virtual DbSet<ProductSupplier> ProductSuppliers { get; set; }

    public virtual DbSet<ProductView> ProductViews { get; set; }

    public virtual DbSet<SearchLog> SearchLogs { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdminAction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__admin_ac__3213E83F788DB3A0");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Admin).WithMany(p => p.AdminActions).HasConstraintName("FK_admin_actions_admin");
        });

        modelBuilder.Entity<Advert>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__adverts__3213E83F5020E759");

            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Company).WithMany(p => p.Adverts).HasConstraintName("FK_adverts_company");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__carts__3213E83F5EF008DB");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Status).HasDefaultValue("active");

            entity.HasOne(d => d.User).WithMany(p => p.Carts).HasConstraintName("FK_carts_user");
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cart_ite__3213E83F583EB985");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Quantity).HasDefaultValue(1);

            entity.HasOne(d => d.Cart).WithMany(p => p.CartItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_cart_items_cart");

            entity.HasOne(d => d.Product).WithMany(p => p.CartItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_cart_items_product");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__categori__3213E83FF5F38EF2");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent).HasConstraintName("FK_categories_parent");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__companie__3213E83F9B8ACC61");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
        });

        modelBuilder.Entity<Component>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__componen__3213E83FC29C404E");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
        });

        modelBuilder.Entity<CreditCard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__credit_c__3213E83F5750599A");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.User).WithMany(p => p.CreditCards)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_credit_cards_user");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__orders__3213E83F9A106CC7");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Status).HasDefaultValue("draft");

            entity.HasOne(d => d.User).WithMany(p => p.Orders).HasConstraintName("FK_orders_user");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__order_it__3213E83F3A08F1AE");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Quantity).HasDefaultValue(1);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_order_items_order");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_order_items_product");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__payments__3213E83FBB970A7B");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Status).HasDefaultValue("pending");

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_payments_order");

            entity.HasOne(d => d.User).WithMany(p => p.Payments).HasConstraintName("FK_payments_user");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__products__3213E83F4B726FCE");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Status).HasDefaultValue("active");

            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasConstraintName("FK_products_category");
        });

        modelBuilder.Entity<ProductComponent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product___3213E83F36C68A18");

            entity.Property(e => e.Quantity).HasDefaultValue(1);

            entity.HasOne(d => d.Component).WithMany(p => p.ProductComponents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pc_component");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductComponents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pc_product");
        });

        modelBuilder.Entity<ProductDesign>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product___3213E83F957D5C64");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductDesigns)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_designs_product");
        });

        modelBuilder.Entity<ProductDesignOption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product___3213E83F983548A2");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Design).WithMany(p => p.ProductDesignOptions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pdo_design");

            entity.HasOne(d => d.LinkedComponent).WithMany(p => p.ProductDesignOptions).HasConstraintName("FK_pdo_component");
        });

        modelBuilder.Entity<ProductSupplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product___3213E83FD3AF97D4");

            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductSuppliers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ps_product");

            entity.HasOne(d => d.Supplier).WithMany(p => p.ProductSuppliers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ps_supplier");
        });

        modelBuilder.Entity<ProductView>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product___3213E83FD1147299");

            entity.Property(e => e.ViewedAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductViews)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_views_product");

            entity.HasOne(d => d.User).WithMany(p => p.ProductViews).HasConstraintName("FK_product_views_user");
        });

        modelBuilder.Entity<SearchLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__search_l__3213E83F2DE95FB6");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.User).WithMany(p => p.SearchLogs).HasConstraintName("FK_search_logs_user");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__supplier__3213E83F734850A2");

            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__transact__3213E83FBC32DBCA");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Order).WithMany(p => p.Transactions).HasConstraintName("FK_transactions_order");

            entity.HasOne(d => d.User).WithMany(p => p.Transactions).HasConstraintName("FK_transactions_user");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83FA106DA45");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_pro__3213E83FDA97E7D1");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.User).WithOne(p => p.UserProfile)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_profiles_user");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
