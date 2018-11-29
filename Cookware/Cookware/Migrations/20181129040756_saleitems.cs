using Microsoft.EntityFrameworkCore.Migrations;

namespace Cookware.Migrations
{
    public partial class saleitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "Image", "Name", "Price", "Sku" },
                values: new object[,]
                {
                    { 11, "Walk away grab some coffee and…Debug with the Bug Mug.", "https://i.etsystatic.com/14324740/r/il/413be1/1178722036/il_570xN.1178722036_jdgl.jpg", "Bug Mug", 8.99m, "48194738837" },
                    { 12, "Open the Wine, it has been a long day.", " https://i.etsystatic.com/6222536/r/il/7b5ae8/1439288282/il_fullxfull.1439288282_ghq5.jpg", "Wine();", 3.99m, "6194730037" },
                    { 13, "It is a logical question.", " https://i.etsystatic.com/15309885/r/il/a52246/1560435265/il_570xN.1560435265_9vge.jpg", "Or Not to Be", 10.95m, "3214735037" },
                    { 14, "The perfect gift for that one person that is THAT programmer. Passive aggression at its finest.", " https://i.etsystatic.com/13197135/r/il/e0723e/1109237450/il_570xN.1109237450_ll52.jpg", "5PM Mug", 10.95m, "8997357351" },
                    { 15, " Software Tee - Computing Top - It's Not A Bug It's An Undocumented Feature", " https://i.etsystatic.com/14803127/r/il/cf25a5/1319272634/il_570xN.1319272634_qeok.jpg", "Feature Tee", 9.99m, "8197357274" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 15);
        }
    }
}
