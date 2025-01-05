using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CouponAPI.Migrations;

/// <inheritdoc />
public partial class Seed_Initial_Coupons_Data : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData(
            table: "Coupons",
            columns: new[] { "Id", "Code", "DiscountAmount", "MinAmount" },
            values: new object[] { 1, "20OFF", 20.0, 5 });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "Coupons",
            keyColumn: "Id",
            keyValue: 1);
    }
}
