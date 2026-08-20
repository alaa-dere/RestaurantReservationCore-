using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Operations;

public class OrderOperations
{
    private readonly RestaurantReservationDbContext _context;

    public OrderOperations(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<Orders> Create(Orders order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task<bool> Update(Orders order)
    {
        var existing = await _context.Orders
            .FirstOrDefaultAsync(o => o.OrderId == order.OrderId);

        if (existing == null)
            return false;

        existing.ReservationId = order.ReservationId;
        existing.EmployeeId = order.EmployeeId;
        existing.OrderDate = order.OrderDate;
        existing.TotalAmount = order.TotalAmount;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int orderId)
    {
        var order = await _context.Orders
            .FirstOrDefaultAsync(o => o.OrderId == orderId);

        if (order == null)
            return false;

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
        return true;
    }
}