using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Operations;

public class ReservationOperations
{
    private readonly RestaurantReservationDbContext _context;

    public ReservationOperations(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<Reservations> Create(Reservations reservation)
    {
        await _context.Reservations.AddAsync(reservation);
        await _context.SaveChangesAsync();
        return reservation;
    }

    public async Task<bool> Update(Reservations reservation)
    {
        var existing = await _context.Reservations
            .FirstOrDefaultAsync(r => r.ReservationId == reservation.ReservationId);

        if (existing == null)
            return false;

        existing.CustomerId = reservation.CustomerId;
        existing.RestaurantId = reservation.RestaurantId;
        existing.TableId = reservation.TableId;
        existing.ReservationDate = reservation.ReservationDate;
        existing.PartySize = reservation.PartySize;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int reservationId)
    {
        var reservation = await _context.Reservations
            .FirstOrDefaultAsync(r => r.ReservationId == reservationId);

        if (reservation == null)
            return false;

        _context.Reservations.Remove(reservation);
        await _context.SaveChangesAsync();
        return true;
    }
    
    public async Task<List<Reservations>> GetReservationsByCustomerAsync(int customerId)
    {
        return await _context.Reservations
            .Where(r => r.CustomerId == customerId)
            .ToListAsync();
    }
    
    public async Task<List<ReservationDetailsView>> GetReservationDetailsAsync()
    {
        return await _context.ReservationDetailsView.ToListAsync();
    }
}