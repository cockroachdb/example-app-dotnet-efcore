using var db = new OrderContext();

Console.WriteLine("insert");
db.Add(new Order
{
    CustomerId = Guid.NewGuid(),
    LineItems = [
        new() { ProductId = Guid.Parse("af788c1d-eaa2-4856-b418-85cfe3ff7824") },
        new() { ProductId = Guid.Parse("bd26032a-8619-4470-bdb8-ab34e45660ed") },
    ],
});
db.Add(new Order
{
    Id = Guid.Parse("f622eb61-0224-45d3-a6e8-49a0b11cf17d"),
    CustomerId = Guid.NewGuid(),
    LineItems = [
        new() { ProductId = Guid.Parse("cf788c1d-eaa2-4856-b418-85cfe3ff7824") },
        new() { ProductId = Guid.Parse("dd26032a-8619-4470-bdb8-ab34e45660ed") },
    ],
});
db.SaveChanges();

Console.WriteLine("\nupdate");
var order = db.Orders
    .Where(b => string.Equals(b.Id.ToString(), "f622eb61-0224-45d3-a6e8-49a0b11cf17d"))
    .First();

order.LineItems?.RemoveAll(x => string.Equals(x.ProductId.ToString(), "cf788c1d-eaa2-4856-b418-85cfe3ff7824"));
order.LineItems?.Add(new() {ProductId = Guid.Parse("eb020f56-50e5-4463-8235-7f29646f07fc")});
db.SaveChanges();

Console.WriteLine("\nselect (all)");
foreach (var o in db.Orders)
{
    Console.WriteLine("{0}", o.Id);

    o.LineItems?.ForEach(li =>
    {
        Console.WriteLine("\t{0}", li.Id);
        Console.WriteLine("\t\t{0}", li.ProductId);
    });
}

Console.WriteLine("\ndelete (all)");
db.RemoveRange(db.Orders);
db.SaveChanges();