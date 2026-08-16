namespace RestaurantReservation.Db.Models;

public class Customers
{
    public int CustomerId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public ICollection<Reservations> Reservations { get; set; } = new List<Reservations>();
}