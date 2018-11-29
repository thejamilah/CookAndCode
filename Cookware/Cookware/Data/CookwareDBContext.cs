﻿using Cookware.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookware.Data
{
    public class CookwareDBContext : DbContext
    {
        public CookwareDBContext(DbContextOptions<CookwareDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ID = 1,
                    Sku = "305361728",
                    Name = "Pancakebot Pancake Printer Griddle",
                    Price = 19.99M,
                    Description = "The Pancake Bot is the world’s first food printer capable of printing pancakes by automatically dispensing batter directly onto a griddle. Pancake designs can be loaded onto the Pancake Bot via SD card. Users can make their own pancake designs with the included software or browse through our online community that is updated with fun, new designs every week.",
                    Image = "https://images.homedepot-static.com/productImages/dc4da6a2-3be5-42f2-ab7a-23053eaca536/svn/black-dash-indoor-grills-pnkb01bk2-64_1000.jpg",
                    LanguageIsCSharp = false
                },
                new Product
                {
                    ID = 2,
                    Sku = "1234567890",
                    Name = "Miito: Water Heater",
                    Price = 22.00M,
                    Description = "Simply fill your cup with water, place it on to the induction base, dip the metal rod into your cup, and turn the device on. The base will heat up the rod, thus heating the water surrounding the rod. The heat up time will vary depending on the size of your drinking vessel, but Miito can heat up a glass of water within 60 seconds or a kettle within in 2 and half minutes.",
                    Image = "https://odditymall.com/includes/content/miito-a-water-heater-that-heats-up-just-the-water-that-s-in-your-cup-thumb.jpg",
                    LanguageIsCSharp = false
                },
                new Product
                {
                    ID = 3,
                    Sku = "1238647253",
                    Name = "Joseph Switch Scale",
                    Price = 36.87M,
                    Description = "This multi-functional digital scale is a versatile kitchen device which offers two options for weighing. You can either place items or bowls directly on to its top, or flip over the integrated lid to create a measuring bowl for weighing loose ingredients or liquids. Featuring an easy-to-read back-lit LCD display and touch-sensitive controls, it’s ready to weigh both liquids and dry foods in the following units – gms, lbs, ozs, fl.ozs, mls up to a maximum capacity of 5kg/176.4 fl.oz/11lb/5000ml. A convenient ‘add and weigh’ function allows multiple ingredients to be weighed during recipe preparation and an auto power-off feature maximizes battery life. It also has non-slip silicone feet.",
                    Image = "https://secure.img1-fg.wfcdn.com/im/00744531/resize-h800%5Ecompr-r85/1570/15708322/Switch+Scale.jpg",
                    LanguageIsCSharp = false
                },
                new Product
                {
                    ID = 4,
                    Sku = "19874278053",
                    Name = "Somabar Automated Bartender",
                    Price = 99.50M,
                    Description = "Create your own menu from a list of 300 cocktails choices from the International Bartenders Association, mix any drink in 10 seconds and never leave a mess with automated cleaning.",
                    Image = "https://www.somabar.com/hs-fs/hubfs/LP%20Images/somabar-new-machine.png?t=1542147816232&width=935&name=somabar-new-machine.png",
                    LanguageIsCSharp = false
                },
                new Product
                {
                    ID = 5,
                    Sku = "19874278053",
                    Name = "Hiku Smart Kitchen Button",
                    Price = 9.00M,
                    Description = "Hiku lives in your kitchen, scans barcodes and recognizes your voice – creating a shared shopping list on your phone so you always know what you need. Use the hiku shopping list app at the store – any store – and your list is always with you. Or connect hiku to online stores to make online shopping a breeze.",
                    Image = "https://static1.squarespace.com/static/51ffe599e4b08f2e358d388a/t/5a6bce718165f5e669c54397/1446508681698/?format=750w",
                    LanguageIsCSharp = false
                },
                new Product
                {
                    ID = 6,
                    Sku = "12836924879",
                    Name = "Range Dial Grill Pro smart cooking thermometer",
                    Price = 19.95M,
                    Description = "Range Dial is a versatile wireless cooking thermometer that can be used with or without your iPhone. Turn the machined stainless steel knob to set an alert, or use the iOS app for more control. ",
                    Image = "https://cdn.shopify.com/s/files/1/0103/5182/products/DSC_5124_grande_df13d5e4-bc6a-45e5-82d2-594c862dead6_1024x1024.jpg?v=1511328894",
                    LanguageIsCSharp = false
                },
                new Product
                {
                    ID = 7,
                    Sku = "12836924879",
                    Name = "Quirky Refuel Smart Propane Tank Gauge",
                    Price = 5.00M,
                    Description = "Monitor your propane supply from anywhere, and receive alerts when it's running low. Position your grill in range of your Wi - Fi network and connect to the Wink App on your mobile device to receive alerts. Tapping the sensor displays an LED reading of the gas level when your smartphone isn't handy, Works with all grills with non - hanging propane tanks",
                    Image = "https://images-na.ssl-images-amazon.com/images/I/61iQ1zrE6eL._SL1001_.jpg",
                    LanguageIsCSharp = false
                },
                new Product
                {
                    ID = 8,
                    Sku = "12836924879",
                    Name = "Nespresso Expert Espresso Machine",
                    Price = 49.99M,
                    Description = "Wake up to premium coffee right in your own home. No need to go to a coffee shop to get your morning fix. That is if you have this Nespresso Expert Espresso Machine. This coffee machine by De'Longhi lets you brew premium coffee in 4 convenient sizes: Americano, Espresso, Lungo, and Ristretto. As for the temperature settings, it has 3 distinct temperatures that you can choose from including medium, hot, and extra hot.All it takes is less than 30 seconds for your cup to be ready.It comes with a capsule testing pack, but after that, you had better get more Nepresso capsules because this is addicting!",
                    Image = "https://d3f8t323tq9ys5.cloudfront.net/uploads/2017/08/71g-omzSENL._SL1500_.jpg",
                    LanguageIsCSharp = false
                },
                new Product
                {
                    ID = 9,
                    Sku = "86-9345021",
                    Name = "KitchenAid Pro Line 7-Quart Stand Mixer - Copper",
                    Price = 89.99M,
                    Description = "Our most powerful Stand Mixer motor are 1.3 HP. The high efficiency, quiet motor delivers .44 HP to the bowl and is designed to run longer and deliver optimum torque with less heat build-up. Our longest lasting quietest stand mixer design with all metal gears. This robust mixer was designed to last longer and deliver ultimate performance with less noise.",
                    Image = "https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcQRcVeKzC6rEjj5LJI0-O7gew2r-vRNqOuzG3WPkLFq8W_z073CyQ5pL5unWlEUz5qjO1jWeK0DDZm0wmMzyfkikVAybgNk&usqp=CAY",
                    LanguageIsCSharp = false
                },
                new Product
                {
                    ID = 10,
                    Sku = "927348829849",
                    Name = "Vacuvita® Home Base One-Touch Vacuum Storage System",
                    Price = 19.99M,
                    Description = "The Vacuvita Home Base is a great way to store food on your kitchen countertop. Instead of taking up space in your cupboard or kitchen, this system vacuum seals its contents every single time it is closed. This means that you can reduce waste (because food will last much longer) and the associated app will also help you keep track of your stored foods so you know when it’s time to eat them. Never eat an unripe avocado again. It’s also perfect for travel, or for a chef on the go.",
                    Image = "https://d3f8t323tq9ys5.cloudfront.net/uploads/2016/06/product-58d758d281e47-Front-700x700.jpg",
                    LanguageIsCSharp = false
                },
                new Product
                {
                    ID = 11,
                    Sku = "48194738837",
                    Name = "Bug Mug",
                    Price = 8.99M,
                    Description = "Walk away grab some coffee and…Debug with the Bug Mug.",
                    Image = "https://i.etsystatic.com/14324740/r/il/413be1/1178722036/il_570xN.1178722036_jdgl.jpg",
                    LanguageIsCSharp = false
                },

                new Product
                {
                    ID = 12,
                    Sku = "6194730037",
                    Name = "WineTime();",
                    Price = 3.99M,
                    Description = "Open the Wine, it has been a long day.",
                    Image = " https://i.etsystatic.com/6222536/r/il/7b5ae8/1439288282/il_fullxfull.1439288282_ghq5.jpg",
                    LanguageIsCSharp = false
                },

                new Product
                {
                    ID = 13,
                    Sku = "3214735037",
                    Name = "Program???",
                    Price = 10.95M,
                    Description = "Jim...I'm a engineer, not a spelling bee champ!",
                    Image = " https://i.etsystatic.com/15309885/r/il/a52246/1560435265/il_570xN.1560435265_9vge.jpg",
                    LanguageIsCSharp = false
                },

                new Product
                {
                    ID = 14,
                    Sku = "8997357351",
                    Name = "5PM Mug",
                    Price = 10.95M,
                    Description = "The perfect gift for that one person that is THAT programmer. Passive aggression at its finest.",
                    Image = " https://i.etsystatic.com/13197135/r/il/e0723e/1109237450/il_570xN.1109237450_ll52.jpg",
                    LanguageIsCSharp = false
                },

                new Product
                {
                    ID = 15,
                    Sku = "8197357274",
                    Name = "Feature Tee",
                    Price = 9.99M,
                    Description = " Software Tee - It's Not A Bug It's An Undocumented Feature",
                    Image = "http://cdn.shopify.com/s/files/1/1306/0683/products/its_not_a_bug_its_a_feature_shirts_376f3779-2e77-4c53-8f2e-31f0064efb69_grande.jpeg?v=1473326028",
                    LanguageIsCSharp = false
                },

                new Product
                {
                    ID = 16,
                    Sku = "92894738849",
                    Name = "See Sharp",
                    Price = 9.99M,
                    Description = "I WEAR GLASSES SO I CAN C#- Funny well - design for C# programmers, computer programmers, IT department, software engineers, web developers, web designers, workers or any coder that is obsessed with all things coding.",
                    Image = "https://ih1.redbubble.net/image.659610062.9120/gptr,1400x,front,black-c,313,133,750,1000-bg,f8f8f8.u3.jpg",
                    LanguageIsCSharp = true

                },

                new Product
                {
                    ID = 17,
                    Sku = "92734334893",
                    Name = "Trust the Sharp",
                    Price = 12.99M,
                    Description = " Keep calm and Trust Sharp. Keep the caffeine and code going and declare your C#",
                    Image = "https://i3.cpcache.com/product/1209496982/keep_calm_and_trust_sharp_mugs.jpg?side=Back&color=WhiteBlackInside&height=460&width=460&qv=90",
                    LanguageIsCSharp = true

                },

                new Product
                {
                    ID = 18,
                    Sku = "92731228437",
                    Name = "Pac Sharp",
                    Price = 14.99M,
                    Description = "Pac C#",
                    Image = " https://ih1.redbubble.net/image.240961388.0811/ra,fitted_scoop,x2000,dd2121:8219e99865,front-c,285,143,750,1000-bg,f8f8f8.u1.jpg",
                    LanguageIsCSharp = true

                },

                new Product
                {
                    ID = 19,
                    Sku = "457131228437",
                    Name = "Sharp Attack",
                    Price = 4.99M,
                    Description = "Be extra and keep your extras in the C Sharp Attack pouch",
                    Image = " https://ih0.redbubble.net/image.437945136.0089/pr,150x100,750x1000-bg,f8f8f8.2u1.jpg",
                    LanguageIsCSharp = true

                },

                new Product
                {
                    ID = 20,
                    Sku = "54212271027",
                    Name = "Sharp iPad Cover",
                    Price = 4.99M,
                    Description = "Protect your iPad from ridicule while you are at Microsoft",
                    Image = "https://ih1.redbubble.net/image.537839260.5113/mwo,x1000,ipad_2_snap-pad,750x1000,f8f8f8.lite-1u1.jpg",
                    LanguageIsCSharp = true

                },

                new Product
                {
                    ID = 21,
                    Sku = "54212271027",
                    Name = "Sharp Duvet",
                    Price = 24.99M,
                    Description = "Careful, there is something Sharp on your bed!",
                    Image = "https://ih1.redbubble.net/image.566658231.9215/dc%2C450x490%2Ctwin%2Cbed-pad%2C420x460%2Cf8f8f8.lite-1u8.jpg",
                    LanguageIsCSharp = true
                }

                );

            modelBuilder.Entity<Order>().HasData(
    new Order
    {
        ID = 1,
        UserID = "default",
        OrderDate = DateTime.Now,
        CreditCard = 0000,
        Total = 0.00M,

    });
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
