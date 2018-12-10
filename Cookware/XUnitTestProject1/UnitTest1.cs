using Cookware.Data;
using Cookware.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        /// <summary>
        /// Test to get product
        /// </summary>
        [Fact]
        public void CanGetProduct()
        {
            //Arrange
            Product product = new Product();
            product.Name = "Spatula";

            //Assert
            Assert.Equal("Spatula", product.Name);
        }

        /// <summary>
        /// Test to set product
        /// </summary>
        [Fact]
        public void CanSetProduct()
        {
            //Arrange
            Product product = new Product()
            {
                Name = "Pancake Printer",
                Image = "http//.something.net/image",
                Price = 19.99M,
                Sku = "124398479",
                Description = "This is a test product"
            };

            product.Name = "Chocolate Printer";

            //Assert
            Assert.Equal("Chocolate Printer", product.Name);
        }


        /// <summary>
        /// test can create, read, update, and delete product in db
        /// </summary>
        [Fact]
        public async void CrudProductInDB()
        {
            //Arrange
            //setup our DB
            //set values

            DbContextOptions<CookwareDBContext> options =
            new DbContextOptionsBuilder<CookwareDBContext>().UseInMemoryDatabase("DbCanSave").Options;

            //Act
            //creating a variable that "gets" the name
            using (CookwareDBContext context = new CookwareDBContext(options))
            {
                Product product = new Product();
                product.Name = "Test Product";
                product.Description = "123 test";
                product.Price = 123.45M;
                product.Image = "someUrl";
                product.LanguageIsCSharp = true;

                ////Act

                context.Products.Add(product);
                context.SaveChanges();

                var productName = await context.Products.FirstOrDefaultAsync(x => x.Name == product.Name);

                //Assert
                Assert.Equal("Test Product", productName.Name);

                //UPDATE
                product.Name = "Update Product";
                context.Products.Update(product);
                context.SaveChanges();

                var updatedHotel = await context.Products.FirstOrDefaultAsync(x => x.Name == product.Name);

                Assert.Equal("Update Product", updatedHotel.Name);

                //DELETE
                context.Products.Remove(product);
                context.SaveChanges();

                var deletedProduct = await context.Products.FirstOrDefaultAsync(x => x.Name == product.Name);

                Assert.True(deletedProduct == null);
            }
        }

        /// <summary>
        /// test can create, read, update, and delete basketItem in db
        /// </summary>
        [Fact]
        public async void CrudBasketItemInDB()
        {
            //Arrange
            //setup our DB
            //set values

            DbContextOptions<CookwareDBContext> options =
            new DbContextOptionsBuilder<CookwareDBContext>().UseInMemoryDatabase("DbCanSave").Options;

            //Act
            //creating a variable that "gets" the name
            using (CookwareDBContext context = new CookwareDBContext(options))
            {
                BasketItem basket = new BasketItem();
                basket.ProductID = 1;
                basket.UserID = "1";
                basket.Quantity = 3;

                ////Act

                context.BasketItems.Add(basket);
                context.SaveChanges();

                var basketQty = await context.BasketItems.FirstOrDefaultAsync(x => x.UserID == basket.UserID);

                //Assert
                Assert.Equal(3, basketQty.Quantity);

                //UPDATE
                basket.Quantity = 7;
                context.BasketItems.Update(basket);
                context.SaveChanges();

                var updatedBasket = await context.BasketItems.FirstOrDefaultAsync(x => x.Quantity == basket.Quantity);

                Assert.Equal(7, updatedBasket.Quantity);

                //DELETE
                context.BasketItems.Remove(basket);
                context.SaveChanges();

                var deletedBasket = await context.BasketItems.FirstOrDefaultAsync(x => x.Quantity == basket.Quantity);

                Assert.True(deletedBasket == null);
            }
        }
    }
}
