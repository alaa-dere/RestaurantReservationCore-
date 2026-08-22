using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Operations;

public class CustomerOperations
{
    private readonly RestaurantReservationDbContext _context;

    public CustomerOperations(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<Customers> Create(Customers customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

    public async Task<bool> Update(Customers customer)
    {
        var existing = await _context.Customers
            .FirstOrDefaultAsync(c => c.CustomerId == customer.CustomerId);

        if (existing == null)
            return false;

        existing.FirstName = customer.FirstName;
        existing.LastName = customer.LastName;
        existing.Email = customer.Email;
        existing.PhoneNumber = customer.PhoneNumber;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int customerId)
    {
        var customer = await _context.Customers
            .FirstOrDefaultAsync(c => c.CustomerId == customerId);

        if (customer == null)
            return false;

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
        return true;
    }
    
    public async Task<List<Customers>> GetCustomersByPartySizeAsync(int partySize)
    {
        var partySizeParameter = new SqlParameter("@PartySize", partySize);

        return await _context.Customers
            .FromSqlRaw("EXEC GetCustomersByPartySize @PartySize", partySizeParameter)
            .AsNoTracking()
            .ToListAsync();
    }
}