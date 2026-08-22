using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;
using Microsoft.Data.SqlClient;

namespace RestaurantReservation.Db.Operations;

public class RestaurantOperations
{
    private readonly RestaurantReservationDbContext _context;

    public RestaurantOperations(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<Restaurants> Create(Restaurants restaurant)
    {
        await _context.Restaurants.AddAsync(restaurant);
        await _context.SaveChangesAsync();
        return restaurant;
    }

    public async Task<bool> Update(Restaurants restaurant)
    {
        var existing = await _context.Restaurants
            .FirstOrDefaultAsync(r => r.RestaurantId == restaurant.RestaurantId);

        if (existing == null)
            return false;

        existing.Name = restaurant.Name;
        existing.Address = restaurant.Address;
        existing.PhoneNumber = restaurant.PhoneNumber;
        existing.OpeningHours = restaurant.OpeningHours;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int restaurantId)
    {
        var restaurant = await _context.Restaurants
            .FirstOrDefaultAsync(r => r.RestaurantId == restaurantId);

        if (restaurant == null)
            return false;

        _context.Restaurants.Remove(restaurant);
        await _context.SaveChangesAsync();
        return true;
    }
    
    public async Task<decimal> GetTotalRevenueAsync(int restaurantId)
    {
        var restaurantIdParameter = new SqlParameter("@restaurantId", restaurantId);
        var result = await _context.Database
            .SqlQueryRaw<decimal>("SELECT dbo.CalculateRestaurantRevenue(@restaurantId) AS Value", restaurantIdParameter)
            .SingleAsync();

        return result;
    }
}