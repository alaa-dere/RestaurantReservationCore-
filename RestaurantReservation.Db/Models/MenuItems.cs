namespace RestaurantReservation.Db.Models;

public class MenuItems
{
    public int ItemId {get; set;}
    public int RestaurantId {get; set;}
    public required string Name {get; set;}
    public required string Description {get; set;}
    public decimal Price {get; set;}
    public Restaurants Restaurants { get; set; } = null!;
    public ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();
}