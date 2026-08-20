using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Operations;

public class TableOperations
{
    private readonly RestaurantReservationDbContext _context;

    public TableOperations(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<Tables> Create(Tables table)
    {
        await _context.Tables.AddAsync(table);
        await _context.SaveChangesAsync();
        return table;
    }

    public async Task<bool> Update(Tables table)
    {
        var existing = await _context.Tables
            .FirstOrDefaultAsync(t => t.TableId == table.TableId);

        if (existing == null)
            return false;

        existing.RestaurantId = table.RestaurantId;
        existing.Capacity = table.Capacity;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int tableId)
    {
        var table = await _context.Tables
            .FirstOrDefaultAsync(t => t.TableId == tableId);

        if (table == null)
            return false;

        _context.Tables.Remove(table);
        await _context.SaveChangesAsync();
        return true;
    }
}