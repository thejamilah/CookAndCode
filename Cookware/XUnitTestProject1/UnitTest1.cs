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
    }
}
