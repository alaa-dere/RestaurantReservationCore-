using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Operations;

public class MenuItemOperations
{
    private readonly RestaurantReservationDbContext _context;

    public MenuItemOperations(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<MenuItems> Create(MenuItems menuItem)
    {
        await _context.MenuItems.AddAsync(menuItem);
        await _context.SaveChangesAsync();
        return menuItem;
    }

    public async Task<bool> Update(MenuItems menuItem)
    {
        var existing = await _context.MenuItems
            .FirstOrDefaultAsync(mi => mi.ItemId == menuItem.ItemId);

        if (existing == null)
            return false;

        existing.RestaurantId = menuItem.RestaurantId;
        existing.Name = menuItem.Name;
        existing.Description = menuItem.Description;
        existing.Price = menuItem.Price;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int itemId)
    {
        var menuItem = await _context.MenuItems
            .FirstOrDefaultAsync(mi => mi.ItemId == itemId);

        if (menuItem == null)
            return false;

        _context.MenuItems.Remove(menuItem);
        await _context.SaveChangesAsync();
        return true;
    }
}