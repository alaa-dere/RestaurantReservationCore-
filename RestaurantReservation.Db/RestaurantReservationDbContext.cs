using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db;

public class RestaurantReservationDbContext : DbContext
{
    public DbSet<Customers> Customers { get; set; }
    public DbSet<Reservations> Reservations { get; set; }
    public DbSet<Tables> Tables { get; set; }
    public DbSet<MenuItems> MenuItems { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<OrderItems> OrderItems { get; set; }
    public DbSet<Restaurants> Restaurants { get; set; }
    public DbSet<Employees> Employees { get; set; }
    public DbSet<ReservationDetailsView> ReservationDetailsView { get; set; }
    public DbSet<EmployeeRestaurantView> EmployeeRestaurantView { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost\\MSSQLSERVER01;" +
            "Database=RestaurantReservationCore;" +
            "Trusted_Connection=True;" +
            "TrustServerCertificate=True;"
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customers>().HasKey(c => c.CustomerId);
        modelBuilder.Entity<Reservations>().HasKey(r => r.ReservationId);
        modelBuilder.Entity<Tables>().HasKey(t => t.TableId);
        modelBuilder.Entity<Employees>().HasKey(e => e.EmployeeId);
        modelBuilder.Entity<Orders>().HasKey(o => o.OrderId);
        modelBuilder.Entity<OrderItems>().HasKey(o => o.OrderItemId);
        modelBuilder.Entity<Restaurants>().HasKey(r => r.RestaurantId);
        modelBuilder.Entity<MenuItems>().HasKey(mi => mi.ItemId);
        modelBuilder.Entity<ReservationDetailsView>().HasNoKey().ToView("ReservationDetailsView");
        modelBuilder.Entity<EmployeeRestaurantView>().HasNoKey().ToView("EmployeeRestaurantView");
        
        modelBuilder.Entity<Reservations>()
            .HasOne(r => r.Customer)
            .WithMany(c => c.Reservations)
            .HasForeignKey(r => r.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Employees>()
            .HasOne(e => e.Restaurant)
            .WithMany(r => r.Employees)
            .HasForeignKey(e => e.RestaurantId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Tables>()
            .HasOne(t => t.Restaurant)
            .WithMany(r => r.Tables)
            .HasForeignKey(t => t.RestaurantId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<MenuItems>()
            .HasOne(mi => mi.Restaurant)
            .WithMany(r => r.MenuItems)
            .HasForeignKey(mi => mi.RestaurantId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Reservations>()
            .HasOne(r => r.Table)
            .WithMany(r => r.Reservations)
            .HasForeignKey(r => r.TableId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Reservations>()
            .HasOne(r => r.Restaurant)
            .WithMany(r => r.Reservations)
            .HasForeignKey(r => r.RestaurantId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Orders>()
            .HasOne(o => o.Reservation)
            .WithMany(r => r.Orders)
            .HasForeignKey(o => o.ReservationId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Orders>()
            .HasOne(o => o.Employee)
            .WithMany(r => r.Orders)
            .HasForeignKey(o => o.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<OrderItems>()
            .HasOne(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<OrderItems>()
            .HasOne(oi => oi.MenuItem)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.ItemId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Reservations>()
            .ToTable("Reservations", table => table.HasCheckConstraint("CK_Reservations_PartySize", "PartySize > 0"));
        modelBuilder.Entity<Tables>()
            .ToTable("Tables", table => table.HasCheckConstraint("CK_Tables_Capacity", "Capacity > 0"));
        modelBuilder.Entity<OrderItems>()
            .ToTable("OrderItems", table => table.HasCheckConstraint("CK_OrderItems_Quantity", "Quantity > 0"));
        modelBuilder.Entity<MenuItems>()
            .ToTable("MenuItems", table => table.HasCheckConstraint("CK_MenuItems_Price", "Price >= 0"));
        modelBuilder.Entity<Orders>()
            .ToTable("Orders", table => table.HasCheckConstraint("CK_Orders_TotalAmount", "TotalAmount >= 0"));
        
        modelBuilder.Entity<MenuItems>().Property(mi => mi.Price).HasPrecision(10, 2);
        modelBuilder.Entity<Orders>().Property(o => o.TotalAmount).HasPrecision(10, 2);
    }
}