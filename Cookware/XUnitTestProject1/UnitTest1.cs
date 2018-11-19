using Cookware.Models;
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
        /// Test to get a user object
        /// </summary>
        [Fact]
        public void CanGetUser()
        {
            //Arrange
            ApplicationUser newUser = new ApplicationUser();
            newUser.FirstName = "Katinka";

            //Assert
            Assert.Equal("Katinka", newUser.FirstName);
        }

        /// <summary>
        /// Test to set a user object
        /// </summary>
        [Fact]
        public void CanSetUser()
        {
            //Arrange
            ApplicationUser newUser = new ApplicationUser()
            {
                FirstName = "Katinka",
                LastName = "Jovavich",
                Birthday = DateTime.Now,
                Language = "C#"
            };

            //Act
            newUser.LastName = "Strovanavich";

            //Assert
            Assert.Equal("Strovanavich", newUser.LastName);
        }
    }
}
