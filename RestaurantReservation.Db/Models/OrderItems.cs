namespace RestaurantReservation.Db.Models;

public class OrderItems
{
    public int OrderItemId {get; set;}
    public int OrderId {get; set;}
    public int ItemId {get; set;}
    public int Quantity {get; set;}
    public Orders Order { get; set; } = null!;
    public MenuItems MenuItem { get; set; } = null!;
}