namespace RestaurantReservation.Db.Models;

public class Restaurants
{
    public int RestaurantId {get; set;}
    public required string Name {get; set;}
    public required string Address {get; set;}
    public required string PhoneNumber {get; set;}
    public required string OpeningHours {get; set;}
    public ICollection<Reservations> Reservations { get; set; } = new List<Reservations>();
    public ICollection<Employees> Employees { get; set; } = new List<Employees>();
    public ICollection<Tables> Tables { get; set; } = new List<Tables>();
    public ICollection<MenuItems> MenuItems { get; set; } = new List<MenuItems>();
}