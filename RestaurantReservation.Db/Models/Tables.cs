namespace RestaurantReservation.Db.Models;

public class Tables
{
    public int TableId {get; set;}
    public int RestaurantId {get; set;}
    public int Capacity{get; set;}
    public Restaurants Restaurant { get; set; } = null!;
    public ICollection<Reservations> Reservations { get; set; } = new List<Reservations>();
}