using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Data;

public static class DataSeeder
{
    public static async Task SeedAsync(RestaurantReservationDbContext context)
    {
        if (!await context.Customers.AnyAsync())
        {
            var customers = new List<Customers>
            {
                new()
                {
                    FirstName = "Alaa",
                    LastName = "Dere",
                    Email = "alaa@gmail.com",
                    PhoneNumber = "0599999991"
                },
                new()
                {
                    FirstName = "Sara",
                    LastName = "Ali",
                    Email = "sara@gmail.com",
                    PhoneNumber = "0599999992"
                },
                new()
                {
                    FirstName = "Omar",
                    LastName = "Nasser",
                    Email = "omar@gmail.com",
                    PhoneNumber = "0599999993"
                },
                new()
                {
                    FirstName = "Lina",
                    LastName = "Saleh",
                    Email = "lina@gmail.com",
                    PhoneNumber = "0599999994"
                },
                new()
                {
                    FirstName = "Yousef",
                    LastName = "Hassan",
                    Email = "yousef@gmail.com",
                    PhoneNumber = "0599999995"
                }
            };

            await context.Customers.AddRangeAsync(customers);
            await context.SaveChangesAsync();
        }
        
        if (!await context.Restaurants.AnyAsync())
        {
            var restaurants = new List<Restaurants>
            {
                new()
                {
                    Name = "Olive Garden",
                    Address = "Ramallah",
                    PhoneNumber = "022988881",
                    OpeningHours = "09:00 - 23:00"
                },
                new()
                {
                    Name = "Palestine Grill",
                    Address = "Nablus",
                    PhoneNumber = "092388882",
                    OpeningHours = "10:00 - 22:00"
                },
                new()
                {
                    Name = "City Restaurant",
                    Address = "Bethlehem",
                    PhoneNumber = "022788883",
                    OpeningHours = "08:00 - 22:00"
                },
                new()
                {
                    Name = "Sea View",
                    Address = "Gaza",
                    PhoneNumber = "082888884",
                    OpeningHours = "11:00 - 23:30"
                },
                new()
                {
                    Name = "Royal Kitchen",
                    Address = "Hebron",
                    PhoneNumber = "022200005",
                    OpeningHours = "09:00 - 22:30"
                }
            };

            await context.Restaurants.AddRangeAsync(restaurants);
            await context.SaveChangesAsync();
        }
        
        if (!await context.Employees.AnyAsync())
        {
            var restaurants = await context.Restaurants
                .OrderBy(r => r.RestaurantId)
                .ToListAsync();

            var employees = new List<Employees>
            {
                new()
                {
                    RestaurantId = restaurants[0].RestaurantId,
                    FirstName = "Khaled",
                    LastName = "Sami",
                    Position = "Manager"
                },
                new()
                {
                    RestaurantId = restaurants[1].RestaurantId,
                    FirstName = "Rami",
                    LastName = "Omar",
                    Position = "Waiter"
                },
                new()
                {
                    RestaurantId = restaurants[2].RestaurantId,
                    FirstName = "Nour",
                    LastName = "Ahmad",
                    Position = "Manager"
                },
                new()
                {
                    RestaurantId = restaurants[3].RestaurantId,
                    FirstName = "Samer",
                    LastName = "Ali",
                    Position = "Chef"
                },
                new()
                {
                    RestaurantId = restaurants[4].RestaurantId,
                    FirstName = "Huda",
                    LastName = "Saleh",
                    Position = "Manager"
                }
            };

            await context.Employees.AddRangeAsync(employees);
            await context.SaveChangesAsync();
        }

        if (!await context.Tables.AnyAsync())
        {
            var restaurants = await context.Restaurants
                .OrderBy(r => r.RestaurantId)
                .ToListAsync();
            var tables = new List<Tables>
            {
                new() { RestaurantId = restaurants[0].RestaurantId, Capacity = 2 },
                new() { RestaurantId = restaurants[1].RestaurantId, Capacity = 4 },
                new() { RestaurantId = restaurants[2].RestaurantId, Capacity = 6 },
                new() { RestaurantId = restaurants[3].RestaurantId, Capacity = 4 },
                new() { RestaurantId = restaurants[4].RestaurantId, Capacity = 8 }
            };
            
            await context.Tables.AddRangeAsync(tables);
            await context.SaveChangesAsync();
        }

        if (!await context.MenuItems.AnyAsync())
        {
            var restaurants = await context.Restaurants
                .OrderBy(r => r.RestaurantId)
                .ToListAsync();
            var menuItems = new List<MenuItems>
            {
                new()
                {
                    RestaurantId = restaurants[0].RestaurantId,
                    Name = "Burger",
                    Description = "Beef burger with fries",
                    Price = 35.00m
                },
                new()
                {
                    RestaurantId = restaurants[1].RestaurantId,
                    Name = "Grilled Chicken",
                    Description = "Grilled chicken with rice",
                    Price = 45.00m
                },
                new()
                {
                    RestaurantId = restaurants[2].RestaurantId,
                    Name = "Pizza",
                    Description = "Cheese pizza",
                    Price = 30.00m
                },
                new()
                {
                    RestaurantId = restaurants[3].RestaurantId,
                    Name = "Fish",
                    Description = "Grilled fish",
                    Price = 55.00m
                },
                new()
                {
                    RestaurantId = restaurants[4].RestaurantId,
                    Name = "Pasta",
                    Description = "Creamy pasta",
                    Price = 40.00m
                }
            };
            
            await context.MenuItems.AddRangeAsync(menuItems);
            await context.SaveChangesAsync();
        }
        
        if (!await context.Reservations.AnyAsync())
        {
            var customers = await context.Customers
                .OrderBy(c => c.CustomerId)
                .ToListAsync();

            var restaurants = await context.Restaurants
                .OrderBy(r => r.RestaurantId)
                .ToListAsync();

            var tables = await context.Tables
                .OrderBy(t => t.TableId)
                .ToListAsync();

            var reservations = new List<Reservations>
            {
                new()
                {
                    CustomerId = customers[0].CustomerId,
                    RestaurantId = restaurants[0].RestaurantId,
                    TableId = tables[0].TableId,
                    ReservationDate = new DateTime(2026, 9, 10, 18, 0, 0),
                    PartySize = 2
                },
                new()
                {
                    CustomerId = customers[1].CustomerId,
                    RestaurantId = restaurants[1].RestaurantId,
                    TableId = tables[1].TableId,
                    ReservationDate = new DateTime(2026, 9, 11, 19, 0, 0),
                    PartySize = 4
                },
                new()
                {
                    CustomerId = customers[2].CustomerId,
                    RestaurantId = restaurants[2].RestaurantId,
                    TableId = tables[2].TableId,
                    ReservationDate = new DateTime(2026, 9, 12, 20, 0, 0),
                    PartySize = 5
                },
                new()
                {
                    CustomerId = customers[3].CustomerId,
                    RestaurantId = restaurants[3].RestaurantId,
                    TableId = tables[3].TableId,
                    ReservationDate = new DateTime(2026, 9, 13, 17, 30, 0),
                    PartySize = 3
                },
                new()
                {
                    CustomerId = customers[4].CustomerId,
                    RestaurantId = restaurants[4].RestaurantId,
                    TableId = tables[4].TableId,
                    ReservationDate = new DateTime(2026, 9, 14, 21, 0, 0),
                    PartySize = 6
                }
            };

            await context.Reservations.AddRangeAsync(reservations);
            await context.SaveChangesAsync();
        }
        
        if (!await context.Reservations.AnyAsync())
        {
            var customers = await context.Customers
                .OrderBy(c => c.CustomerId)
                .ToListAsync();

            var restaurants = await context.Restaurants
                .OrderBy(r => r.RestaurantId)
                .ToListAsync();

            var tables = await context.Tables
                .OrderBy(t => t.TableId)
                .ToListAsync();

            var reservations = new List<Reservations>
            {
                new()
                {
                    CustomerId = customers[0].CustomerId,
                    RestaurantId = restaurants[0].RestaurantId,
                    TableId = tables[0].TableId,
                    ReservationDate = new DateTime(2026, 9, 10, 18, 0, 0),
                    PartySize = 2
                },
                new()
                {
                    CustomerId = customers[1].CustomerId,
                    RestaurantId = restaurants[1].RestaurantId,
                    TableId = tables[1].TableId,
                    ReservationDate = new DateTime(2026, 9, 11, 19, 0, 0),
                    PartySize = 4
                },
                new()
                {
                    CustomerId = customers[2].CustomerId,
                    RestaurantId = restaurants[2].RestaurantId,
                    TableId = tables[2].TableId,
                    ReservationDate = new DateTime(2026, 8, 12, 20, 0, 0),
                    PartySize = 5
                },
                new()
                {
                    CustomerId = customers[3].CustomerId,
                    RestaurantId = restaurants[3].RestaurantId,
                    TableId = tables[3].TableId,
                    ReservationDate = new DateTime(2026, 9, 13, 17, 30, 0),
                    PartySize = 3
                },
                new()
                {
                    CustomerId = customers[4].CustomerId,
                    RestaurantId = restaurants[4].RestaurantId,
                    TableId = tables[4].TableId,
                    ReservationDate = new DateTime(2026, 9, 14, 21, 0, 0),
                    PartySize = 6
                }
            };

            await context.Reservations.AddRangeAsync(reservations);
            await context.SaveChangesAsync();
        }
        
        if (!await context.Orders.AnyAsync())
        {
            var reservations = await context.Reservations
                .OrderBy(r => r.ReservationId)
                .ToListAsync();

            var employees = await context.Employees
                .OrderBy(e => e.EmployeeId)
                .ToListAsync();

            var orders = new List<Orders>
            {
                new()
                {
                    ReservationId = reservations[0].ReservationId,
                    EmployeeId = employees[0].EmployeeId,
                    OrderDate = new DateTime(2026, 9, 10, 18, 15, 0),
                    TotalAmount = 70.00m
                },
                new()
                {
                    ReservationId = reservations[1].ReservationId,
                    EmployeeId = employees[1].EmployeeId,
                    OrderDate = new DateTime(2026, 9, 11, 19, 20, 0),
                    TotalAmount = 90.00m
                },
                new()
                {
                    ReservationId = reservations[2].ReservationId,
                    EmployeeId = employees[2].EmployeeId,
                    OrderDate = new DateTime(2026, 9, 12, 20, 10, 0),
                    TotalAmount = 60.00m
                },
                new()
                {
                    ReservationId = reservations[3].ReservationId,
                    EmployeeId = employees[3].EmployeeId,
                    OrderDate = new DateTime(2026, 9, 13, 17, 45, 0),
                    TotalAmount = 110.00m
                },
                new()
                {
                    ReservationId = reservations[4].ReservationId,
                    EmployeeId = employees[4].EmployeeId,
                    OrderDate = new DateTime(2026, 9, 14, 21, 10, 0),
                    TotalAmount = 80.00m
                }
            };

            await context.Orders.AddRangeAsync(orders);
            await context.SaveChangesAsync();
        }
        
        if (!await context.OrderItems.AnyAsync())
        {
            var orders = await context.Orders
                .OrderBy(o => o.OrderId)
                .ToListAsync();

            var menuItems = await context.MenuItems
                .OrderBy(mi => mi.ItemId)
                .ToListAsync();

            var orderItems = new List<OrderItems>
            {
                new()
                {
                    OrderId = orders[0].OrderId,
                    ItemId = menuItems[0].ItemId,
                    Quantity = 2
                },
                new()
                {
                    OrderId = orders[1].OrderId,
                    ItemId = menuItems[1].ItemId,
                    Quantity = 2
                },
                new()
                {
                    OrderId = orders[2].OrderId,
                    ItemId = menuItems[2].ItemId,
                    Quantity = 2
                },
                new()
                {
                    OrderId = orders[3].OrderId,
                    ItemId = menuItems[3].ItemId,
                    Quantity = 2
                },
                new()
                {
                    OrderId = orders[4].OrderId,
                    ItemId = menuItems[4].ItemId,
                    Quantity = 2
                }
            };

            await context.OrderItems.AddRangeAsync(orderItems);
            await context.SaveChangesAsync();
        }
    }
}