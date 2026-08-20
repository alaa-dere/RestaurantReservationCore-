using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Operations;

public class OrderItemOperations
{
    private readonly RestaurantReservationDbContext _context;

    public OrderItemOperations(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<OrderItems> Create(OrderItems orderItem)
    {
        await _context.OrderItems.AddAsync(orderItem);
        await _context.SaveChangesAsync();
        return orderItem;
    }

    public async Task<bool> Update(OrderItems orderItem)
    {
        var existing = await _context.OrderItems
            .FirstOrDefaultAsync(oi => oi.OrderItemId == orderItem.OrderItemId);

        if (existing == null)
            return false;

        existing.OrderId = orderItem.OrderId;
        existing.ItemId = orderItem.ItemId;
        existing.Quantity = orderItem.Quantity;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int orderItemId)
    {
        var orderItem = await _context.OrderItems
            .FirstOrDefaultAsync(oi => oi.OrderItemId == orderItemId);

        if (orderItem == null)
            return false;

        _context.OrderItems.Remove(orderItem);
        await _context.SaveChangesAsync();
        return true;
    }
}