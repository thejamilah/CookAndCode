using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cookware.Migrations
{
    public partial class seedingdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sku = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "Image", "Name", "Price", "Sku" },
                values: new object[,]
                {
                    { 1, "The Pancake Bot is the world’s first food printer capable of printing pancakes by automatically dispensing batter directly onto a griddle. Pancake designs can be loaded onto the Pancake Bot via SD card. Users can make their own pancake designs with the included software or browse through our online community that is updated with fun, new designs every week.", "https://images.homedepot-static.com/productImages/dc4da6a2-3be5-42f2-ab7a-23053eaca536/svn/black-dash-indoor-grills-pnkb01bk2-64_1000.jpg", "Pancakebot Pancake Printer Griddle", 199.99m, "305361728" },
                    { 2, "Simply fill your cup with water, place it on to the induction base, dip the metal rod into your cup, and turn the device on. The base will heat up the rod, thus heating the water surrounding the rod. The heat up time will vary depending on the size of your drinking vessel, but Miito can heat up a glass of water within 60 seconds or a kettle within in 2 and half minutes.", "https://odditymall.com/includes/content/miito-a-water-heater-that-heats-up-just-the-water-that-s-in-your-cup-thumb.jpg", "Miito: Water Heater", 102.00m, "1234567890" },
                    { 3, "This multi-functional digital scale is a versatile kitchen device which offers two options for weighing. You can either place items or bowls directly on to its top, or flip over the integrated lid to create a measuring bowl for weighing loose ingredients or liquids. Featuring an easy-to-read back-lit LCD display and touch-sensitive controls, it’s ready to weigh both liquids and dry foods in the following units – gms, lbs, ozs, fl.ozs, mls up to a maximum capacity of 5kg/176.4 fl.oz/11lb/5000ml. A convenient ‘add and weigh’ function allows multiple ingredients to be weighed during recipe preparation and an auto power-off feature maximizes battery life. It also has non-slip silicone feet.", "https://secure.img1-fg.wfcdn.com/im/00744531/resize-h800%5Ecompr-r85/1570/15708322/Switch+Scale.jpg", "Joseph Switch Scale", 36.87m, "1238647253" },
                    { 4, "Create your own menu from a list of 300 cocktails choices from the International Bartenders Association, mix any drink in 10 seconds and never leave a mess with automated cleaning.", "https://www.somabar.com/hs-fs/hubfs/LP%20Images/somabar-new-machine.png?t=1542147816232&width=935&name=somabar-new-machine.png", "Somabar Automated Bartender", 4995m, "19874278053" },
                    { 5, "Hiku lives in your kitchen, scans barcodes and recognizes your voice – creating a shared shopping list on your phone so you always know what you need. Use the hiku shopping list app at the store – any store – and your list is always with you. Or connect hiku to online stores to make online shopping a breeze.", "https://static1.squarespace.com/static/51ffe599e4b08f2e358d388a/t/5a6bce718165f5e669c54397/1446508681698/?format=750w", "Hiku Smart Kitchen Button", 79.00m, "19874278053" },
                    { 6, "Range Dial is a versatile wireless cooking thermometer that can be used with or without your iPhone. Turn the machined stainless steel knob to set an alert, or use the iOS app for more control. ", "https://cdn.shopify.com/s/files/1/0103/5182/products/DSC_5124_grande_df13d5e4-bc6a-45e5-82d2-594c862dead6_1024x1024.jpg?v=1511328894", "Range Dial Grill Pro smart cooking thermometer", 119.95m, "12836924879" },
                    { 7, "Monitor your propane supply from anywhere, and receive alerts when it's running low. Position your grill in range of your Wi - Fi network and connect to the Wink App on your mobile device to receive alerts. Tapping the sensor displays an LED reading of the gas level when your smartphone isn't handy, Works with all grills with non - hanging propane tanks", "https://images-na.ssl-images-amazon.com/images/I/61iQ1zrE6eL._SL1001_.jpg", "Quirky Refuel Smart Propane Tank Gauge", 65.00m, "12836924879" },
                    { 8, "Wake up to premium coffee right in your own home. No need to go to a coffee shop to get your morning fix. That is if you have this Nespresso Expert Espresso Machine. This coffee machine by De'Longhi lets you brew premium coffee in 4 convenient sizes: Americano, Espresso, Lungo, and Ristretto. As for the temperature settings, it has 3 distinct temperatures that you can choose from including medium, hot, and extra hot.All it takes is less than 30 seconds for your cup to be ready.It comes with a capsule testing pack, but after that, you had better get more Nepresso capsules because this is addicting!", "https://d3f8t323tq9ys5.cloudfront.net/uploads/2017/08/71g-omzSENL._SL1500_.jpg", "Nespresso Expert Espresso Machine", 329.99m, "12836924879" },
                    { 9, "Wake up to premium coffee right in your own home. No need to go to a coffee shop to get your morning fix. That is if you have this Nespresso Expert Espresso Machine. This coffee machine by De'Longhi lets you brew premium coffee in 4 convenient sizes: Americano, Espresso, Lungo, and Ristretto. As for the temperature settings, it has 3 distinct temperatures that you can choose from including medium, hot, and extra hot.All it takes is less than 30 seconds for your cup to be ready.It comes with a capsule testing pack, but after that, you had better get more Nepresso capsules because this is addicting!", "https://d3f8t323tq9ys5.cloudfront.net/uploads/2017/08/71g-omzSENL._SL1500_.jpg", "Nespresso Expert Espresso Machine", 329.99m, "12836924879" },
                    { 10, "The Vacuvita Home Base is a great way to store food on your kitchen countertop. Instead of taking up space in your cupboard or kitchen, this system vacuum seals its contents every single time it is closed. This means that you can reduce waste (because food will last much longer) and the associated app will also help you keep track of your stored foods so you know when it’s time to eat them. Never eat an unripe avocado again. It’s also perfect for travel, or for a chef on the go.", "https://d3f8t323tq9ys5.cloudfront.net/uploads/2016/06/product-58d758d281e47-Front-700x700.jpg", "Vacuvita® Home Base One-Touch Vacuum Storage System", 299.99m, "927348829849" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
