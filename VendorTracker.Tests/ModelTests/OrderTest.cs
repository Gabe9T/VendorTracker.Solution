using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VendorTracker.Models;

namespace VendorTracker.TestTools
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void OrderConstructor_CreatesInstanceOfOrder_Order()
        {
            DateTime orderDate = DateTime.Now;
            Order newOrder = new Order("Croissants", "Freshly baked croissants", 10.99, orderDate);

            Assert.AreEqual("Croissants", newOrder.Title);
            Assert.AreEqual("Freshly baked croissants", newOrder.Description);
            Assert.AreEqual(10.99, newOrder.Price);
            Assert.AreEqual(orderDate, newOrder.Date);
            Assert.AreNotEqual(0, newOrder.Id);
        }

        [TestMethod]
        public void OrderConstructor_GeneratesUniqueIdsForOrders()
        {
            Order order1 = new Order("Croissants", "Freshly baked croissants", 10.99, DateTime.Now);
            Order order2 = new Order("Baguette", "French baguette", 5.99, DateTime.Now);

            Assert.AreNotEqual(order1.Id, order2.Id, "Ids are not unique for different orders");
        }

        [TestMethod]
        public void GetDescription_ReturnsOrderDescription_String()
        {
            Order newOrder = new Order("Croissants", "Freshly baked croissants", 10.99, DateTime.Now);
            string description = newOrder.GetDescription();

            Assert.AreEqual("Freshly baked croissants", description);
        }

        [TestMethod]
        public void SetDescription_ModifiesOrderDescription_DescriptionUpdated()
        {
            Order newOrder = new Order("Croissants", "Freshly baked croissants", 10.99, DateTime.Now);
            newOrder.SetDescription("Delicious croissants with butter");

            Assert.AreEqual("Delicious croissants with butter", newOrder.Description);
        }

        [TestMethod]
        public void GetPrice_ReturnsOrderPrice_Double()
        {
            Order newOrder = new Order("Croissants", "Freshly baked croissants", 10.99, DateTime.Now);
            double price = newOrder.GetPrice();

            Assert.AreEqual(10.99, price);
        }

        [TestMethod]
        public void SetPrice_ModifiesOrderPrice_PriceUpdated()
        {
            Order newOrder = new Order("Croissants", "Freshly baked croissants", 10.99, DateTime.Now);
            newOrder.SetPrice(12.99);

            Assert.AreEqual(12.99, newOrder.Price);
        }
    }
}