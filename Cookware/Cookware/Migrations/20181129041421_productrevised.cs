using Microsoft.EntityFrameworkCore.Migrations;

namespace Cookware.Migrations
{
    public partial class productrevised : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 12,
                column: "Name",
                value: "WineTime();");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Jim...I'm a engineer, not a spelling bee champ!", "Program???" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 15,
                column: "Description",
                value: " Software Tee - It's Not A Bug It's An Undocumented Feature");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 12,
                column: "Name",
                value: "Wine();");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "Description", "Name" },
                values: new object[] { "It is a logical question.", "Or Not to Be" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 15,
                column: "Description",
                value: " Software Tee - Computing Top - It's Not A Bug It's An Undocumented Feature");
        }
    }
}
