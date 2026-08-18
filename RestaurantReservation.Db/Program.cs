using RestaurantReservation.Db;
using RestaurantReservation.Db.Data;

using var context = new RestaurantReservationDbContext();

await DataSeeder.SeedAsync(context);

Console.WriteLine("Database seeded successfully.");