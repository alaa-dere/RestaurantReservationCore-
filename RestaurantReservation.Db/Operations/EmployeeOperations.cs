using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Operations;

public class EmployeeOperations
{
    private readonly RestaurantReservationDbContext _context;

    public EmployeeOperations(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<Employees> Create(Employees employee)
    {
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<bool> Update(Employees employee)
    {
        var existing = await _context.Employees
            .FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);

        if (existing == null)
            return false;

        existing.RestaurantId = employee.RestaurantId;
        existing.FirstName = employee.FirstName;
        existing.LastName = employee.LastName;
        existing.Position = employee.Position;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int employeeId)
    {
        var employee = await _context.Employees
            .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

        if (employee == null)
            return false;

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
        return true;
    }
}