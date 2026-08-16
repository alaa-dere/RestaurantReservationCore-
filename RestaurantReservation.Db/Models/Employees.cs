namespace RestaurantReservation.Db.Models;

public class Employees
{
    public int EmployeeId {get; set;}
    public int RestaurantId {get; set;}
    public required string FirstName {get; set;}
    public required string LastName {get; set;}
    public required string Position {get; set;}
    public Restaurants Restaurants { get; set; } = null!;
    public ICollection<Orders> Orders {get; set;}=new List<Orders>();
}