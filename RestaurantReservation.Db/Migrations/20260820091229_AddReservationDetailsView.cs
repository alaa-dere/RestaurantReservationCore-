using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddReservationDetailsView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                                     CREATE VIEW ReservationDetailsView AS
                                     SELECT
                                         r.ReservationId,
                                         r.ReservationDate,
                                         r.PartySize,
                                         c.CustomerId,
                                         c.FirstName AS CustomerFirstName,
                                         c.LastName AS CustomerLastName,
                                         res.RestaurantId,
                                         res.Name AS RestaurantName,
                                         res.Address AS RestaurantAddress
                                     FROM Reservations r
                                     INNER JOIN Customers c
                                     ON r.CustomerId = c.CustomerId
                                     INNER JOIN Restaurants res
                                     ON r.RestaurantId = res.RestaurantId;
                                 """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""DROP VIEW ReservationDetailsView;""");
        }
    }
}
