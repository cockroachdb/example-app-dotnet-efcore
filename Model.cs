using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

public class OrderContext : DbContext
{
  public DbSet<Order> Orders { get; set; }
  public DbSet<LineItem> LineItems { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder builder)
  {
    var url = Environment.GetEnvironmentVariable("DATABASE_URL");

    if (string.IsNullOrEmpty(url))
    {
      throw new Exception("missing DATABASE_URL env var");
    }

    builder.UseNpgsql(url);
  }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Order>()
               .Property(b => b.Id)
               .HasDefaultValueSql("gen_random_uuid()");

        builder.Entity<LineItem>()
               .Property(b => b.Id)
               .HasDefaultValueSql("gen_random_uuid()");
    }
}

[Table("orders")]
public class Order
{
  [Column("id")]
  public Guid Id { get; set; }

  [Column("customer_id")]
  public required Guid CustomerId { get; set; }

  public List<LineItem>? LineItems { get; set; }
}

[Table("line_items")]
public class LineItem
{
  [Column("id")]
  public Guid Id { get; set; }
  
  [Column("product_id")]
  public required Guid ProductId { get; set; }

  [Column("order_id")]
  public Guid OrderId { get; set; }

  public Order? Order { get; set; }
}