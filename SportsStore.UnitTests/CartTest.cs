using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.Domain.Entities;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class CartTest
    {
        [TestMethod]
        public void Can_Add_Items_To_Cart()
        {
            //Arrange
            Cart cart = new Cart();
            Product p1 = new Product {ProductId = 1, Name = "Socks", Price = 10, Category = "Soft and fresh"};
            Product p2 = new Product { ProductId = 2, Name = "Watch", Price = 10000, Category = "Style quotient" };

            //Act
            cart.AddItem(p1, 2);
            cart.AddItem(p2, 1);

            //Assert
            Assert.AreEqual(cart.Lines.Count, 2);
            Assert.AreEqual(cart.Lines.FirstOrDefault().Product, p1);
        }

        [TestMethod]
        public void Can_Remove_Items_From_Cart()
        {
            //Arrange
            Cart cart = new Cart();
            Product p1 = new Product { ProductId = 1, Name = "Socks", Price = 10, Category = "Soft and fresh" };
            Product p2 = new Product { ProductId = 2, Name = "Watch", Price = 10000, Category = "Style quotient" };
            cart.AddItem(p1, 2);
            cart.AddItem(p2, 1);

            //Act
            cart.RemoveItem(p2);

            //Assert
            Assert.AreEqual(cart.Lines.Count, 1);
            Assert.AreEqual(0, cart.Lines.Count(p => p.Product.ProductId == p2.ProductId));
        }

        [TestMethod]
        public void Can_Add_Quantity_To_Cart()
        {
            //Arrange
            Cart cart = new Cart();
            Product p1 = new Product { ProductId = 1, Name = "Socks", Price = 10, Category = "Soft and fresh" };
            Product p2 = new Product { ProductId = 2, Name = "Watch", Price = 10000, Category = "Style quotient" };
            cart.AddItem(p1, 2);
            cart.AddItem(p2, 1);

            //Act
            cart.AddItem(p1, 2);

            //Assert
            Assert.AreEqual(4, cart.Lines.FirstOrDefault(p => p.Product.ProductId == p1.ProductId).Quantity);
            Assert.AreEqual(cart.Lines.FirstOrDefault().Product, p1);
        }

        [TestMethod]
        public void Should_Give_Total_Value()
        {
            //Arrange
            Cart cart = new Cart();
            Product p1 = new Product { ProductId = 1, Name = "Socks", Price = 10, Category = "Soft and fresh" };
            Product p2 = new Product { ProductId = 2, Name = "Watch", Price = 28, Category = "Style quotient" };
            cart.AddItem(p1, 2);
            cart.AddItem(p2, 1);

            //Act
            var result = cart.ComputeTotalValue();

            //Assert
            Assert.AreEqual(48, result);
        }
    }
}
