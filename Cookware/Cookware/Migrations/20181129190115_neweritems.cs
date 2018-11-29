using Microsoft.EntityFrameworkCore.Migrations;

namespace Cookware.Migrations
{
    public partial class neweritems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 15,
                column: "Image",
                value: "http://cdn.shopify.com/s/files/1/1306/0683/products/its_not_a_bug_its_a_feature_shirts_376f3779-2e77-4c53-8f2e-31f0064efb69_grande.jpeg?v=1473326028");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 16,
                column: "Image",
                value: "https://ih1.redbubble.net/image.659610062.9120/gptr,1400x,front,black-c,313,133,750,1000-bg,f8f8f8.u3.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 21,
                column: "Image",
                value: "https://ih1.redbubble.net/image.566658231.9215/dc%2C450x490%2Ctwin%2Cbed-pad%2C420x460%2Cf8f8f8.lite-1u8.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 15,
                column: "Image",
                value: " https://i.etsystatic.com/14803127/r/il/cf25a5/1319272634/il_570xN.1319272634_qeok.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 16,
                column: "Image",
                value: "https://d3f8t323tq9ys5.cloudfront.net/uploads/2016/06/product-58d758d281e47-Front-700x700.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 21,
                column: "Image",
                value: " https://d1ielco78gv5pf.cloudfront.net/assets/clear-495a83e08fc8e5d7569efe6339a1228ee08292fa1f2bee8e0be6532990cb3852.gif");
        }
    }
}
