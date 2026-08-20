using RestaurantReservation.Db;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Operations;

using var context = new RestaurantReservationDbContext();

await DataSeeder.SeedAsync(context);
await TestCustomerCrudAsync(context);
await TestRestaurantCrudAsync(context);
await TestEmployeeCrudAsync(context);
await TestTableCrudAsync(context);
await TestMenuItemCrudAsync(context);
await TestReservationCrudAsync(context);
await TestOrderCrudAsync(context);
await TestOrderItemCrudAsync(context);

static async Task TestCustomerCrudAsync(RestaurantReservationDbContext context)
{
    Console.WriteLine("\n Customer CRUD");

    var operations = new CustomerOperations(context);
    var customer = new Customers
    {
        FirstName = "Mariam",
        LastName = "Naser",
        Email = "mariam.test@example.com",
        PhoneNumber = "0599999999"
    };
    var created = await operations.Create(customer);
    Console.WriteLine($"Created Customer: {created.CustomerId}");
    
    created.Email = "mariam@example.com";
    var updated = await operations.Update(created);
    Console.WriteLine(updated ? "Customer updated successfully." : "Customer update failed.");

    var deleted = await operations.Delete(created.CustomerId);
    Console.WriteLine(deleted ? "Customer deleted successfully." : "Customer delete failed.");
}

static async Task TestRestaurantCrudAsync(RestaurantReservationDbContext context)
{
    Console.WriteLine("\n Restaurant CRUD");

    var operations = new RestaurantOperations(context);
    var restaurant = new Restaurants
    {
        Name = "Test Restaurant",
        Address = "Ramallah",
        PhoneNumber = "022999999",
        OpeningHours = "10:00 - 22:00"
    };
    var created = await operations.Create(restaurant);
    Console.WriteLine($"Created Restaurant: {created.RestaurantId}");

    created.Name = "Restaurant";
    var updated = await operations.Update(created);
    Console.WriteLine(updated ? "Restaurant updated successfully." : "Restaurant update failed.");

    var deleted = await operations.Delete(created.RestaurantId);
    Console.WriteLine(deleted ? "Restaurant deleted successfully." : "Restaurant delete failed.");
}

static async Task TestEmployeeCrudAsync(RestaurantReservationDbContext context)
{
    Console.WriteLine("\n Employee CRUD");

    var operations = new EmployeeOperations(context);
    var employee = new Employees
    {
        RestaurantId = 1,
        FirstName = "Test",
        LastName = "Employee",
        Position = "Waiter"
    };
    var created = await operations.Create(employee);
    Console.WriteLine($"Created Employee: {created.EmployeeId}");

    created.Position = "Manager";
    var updated = await operations.Update(created);
    Console.WriteLine(updated ? "Employee updated successfully." : "Employee update failed.");

    var deleted = await operations.Delete(created.EmployeeId);
    Console.WriteLine(deleted ? "Employee deleted successfully." : "Employee delete failed.");
}

static async Task TestTableCrudAsync(RestaurantReservationDbContext context)
{
    Console.WriteLine("\n Table CRUD");

    var operations = new TableOperations(context);
    var table = new Tables
    {
        RestaurantId = 1,
        Capacity = 4
    };
    var created = await operations.Create(table);
    Console.WriteLine($"Created Table: {created.TableId}");

    created.Capacity = 6;
    var updated = await operations.Update(created);
    Console.WriteLine(updated ? "Table updated successfully." : "Table update failed.");

    var deleted = await operations.Delete(created.TableId);
    Console.WriteLine(deleted ? "Table deleted successfully." : "Table delete failed.");
}

static async Task TestMenuItemCrudAsync(RestaurantReservationDbContext context)
{
    Console.WriteLine("\n Menu Item CRUD");

    var operations = new MenuItemOperations(context);
    var menuItem = new MenuItems
    {
        RestaurantId = 1,
        Name = "Test Pasta",
        Description = "Test pasta",
        Price = 25m
    };
    var created = await operations.Create(menuItem);
    Console.WriteLine($"Created Menu Item: {created.ItemId}");

    created.Price = 30m;
    var updated = await operations.Update(created);
    Console.WriteLine(updated ? "Menu item updated successfully." : "Menu item update failed.");

    var deleted = await operations.Delete(created.ItemId);
    Console.WriteLine(deleted ? "Menu item deleted successfully." : "Menu item delete failed.");
}

static async Task TestReservationCrudAsync(RestaurantReservationDbContext context)
{
    Console.WriteLine("\n Reservation CRUD ");

    var operations = new ReservationOperations(context);
    var reservation = new Reservations
    {
        CustomerId = 1,
        RestaurantId = 1,
        TableId = 1,
        ReservationDate = DateTime.Now,
        PartySize = 2
    };
    var created = await operations.Create(reservation);
    Console.WriteLine($"Created Reservation: {created.ReservationId}");

    created.PartySize = 3;
    var updated = await operations.Update(created);
    Console.WriteLine(updated ? "Reservation updated successfully." : "Reservation update failed.");

    var deleted = await operations.Delete(created.ReservationId);
    Console.WriteLine(deleted ? "Reservation deleted successfully." : "Reservation delete failed.");
}

static async Task TestOrderCrudAsync(RestaurantReservationDbContext context)
{
    Console.WriteLine("\n Order CRUD ");

    var operations = new OrderOperations(context);
    var order = new Orders
    {
        ReservationId = 1,
        EmployeeId = 1,
        OrderDate = DateTime.Now,
        TotalAmount = 50m
    };
    var created = await operations.Create(order);
    Console.WriteLine($"Created Order: {created.OrderId}");

    created.TotalAmount = 65m;
    var updated = await operations.Update(created);
    Console.WriteLine(updated ? "Order updated successfully." : "Order update failed.");

    var deleted = await operations.Delete(created.OrderId);
    Console.WriteLine(deleted ? "Order deleted successfully." : "Order delete failed.");
}

static async Task TestOrderItemCrudAsync(RestaurantReservationDbContext context)
{
    Console.WriteLine("\n Order Item CRUD ");

    var operations = new OrderItemOperations(context);
    var orderItem = new OrderItems
    {
        OrderId = 1,
        ItemId = 1,
        Quantity = 2
    };
    var created = await operations.Create(orderItem);
    Console.WriteLine($"Created Order Item: {created.OrderItemId}");

    created.Quantity = 3;
    var updated = await operations.Update(created);
    Console.WriteLine(updated ? "Order item updated successfully." : "Order item update failed.");

    var deleted = await operations.Delete(created.OrderItemId);
    Console.WriteLine(deleted ? "Order item deleted successfully." : "Order item delete failed.");
}
