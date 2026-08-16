namespace RestaurantReservation.Db.Models;

public class Reservations
{
    public int ReservationId { get; set; }
    public int CustomerId {get; set;}
    public int RestaurantId {get; set;}
    public int TableId {get; set;}
    public DateTime ReservationDate {get; set;}
    public int PartySize {get; set;}
    public Customers Customers { get; set; } = null!;
    public Restaurants Restaurants { get; set; } = null!;
    public Tables Tables { get; set; } = null!;
    public ICollection<Orders> Orders { get; set; } = new List<Orders>();
}