using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeRestaurantView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                                     CREATE VIEW EmployeeRestaurantView AS
                                     SELECT
                                         e.EmployeeId,
                                         e.FirstName,
                                         e.LastName,
                                         e.Position,
                                         r.RestaurantId,
                                         r.Name AS RestaurantName,
                                         r.Address AS RestaurantAddress
                                     FROM Employees e
                                     INNER JOIN Restaurants r
                                     ON e.RestaurantId = r.RestaurantId;
                                 """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""DROP VIEW EmployeeRestaurantView;""");
        }
    }
}
