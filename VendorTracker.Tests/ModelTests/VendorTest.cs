using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using VendorTracker.Models;

namespace VendorTracker.TestTools
{
    [TestClass]
    public class VendorTests
    {
        [TestMethod]
        public void Vendor_Constructor_CreatesValidVendor()
        {
            Vendor newVendor = new Vendor("VendorName", "VendorDescription");

            Assert.AreEqual("VendorName", newVendor.Name, "Name not set correctly");
            Assert.AreEqual("VendorDescription", newVendor.Description, "Description not set correctly");
            Assert.IsNotNull(newVendor.Orders, "Orders collection not initialized");
            Assert.AreNotEqual(0, newVendor.Id, "Id not generated correctly");
        }

        [TestMethod]
        public void Vendor_AddOrder_AddsOrderToOrdersCollection()
        {
            Vendor vendor = new Vendor("VendorName", "VendorDescription");
            Order order = new Order("OrderTitle", "OrderDescription", 19.99, DateTime.Now);

            vendor.Orders.Add(order);

            CollectionAssert.Contains(vendor.Orders, order, "Order not added to Orders collection");
        }

        [TestMethod]
        public void Vendor_AddOrder_DoesNotDuplicateOrders()
        {
            Vendor vendor = new Vendor("VendorName", "VendorDescription");
            Order order = new Order("OrderTitle", "OrderDescription", 19.99, DateTime.Now);

            vendor.Orders.Add(order);
            vendor.Orders.Add(order);  // Adding the same order again

            Assert.AreEqual(1, vendor.Orders.Count, "Adding the same order multiple times duplicates it");
        }

        [TestMethod]
        public void Vendor_GetOrders_ReturnsOrdersCollection()
        {
            Vendor vendor = new Vendor("VendorName", "VendorDescription");
            Order order1 = new Order("OrderTitle1", "OrderDescription1", 19.99, DateTime.Now);
            Order order2 = new Order("OrderTitle2", "OrderDescription2", 29.99, DateTime.Now);
            vendor.Orders.Add(order1);
            vendor.Orders.Add(order2);

            List<Order> orders = vendor.GetOrders();

            CollectionAssert.AreEqual(vendor.Orders, orders, "GetOrders did not return the correct Orders collection");
        }

        [TestMethod]
        public void Vendor_GetTotalOrdersPrice_ReturnsCorrectTotalPrice()
        {
            Vendor vendor = new Vendor("VendorName", "VendorDescription");
            Order order1 = new Order("OrderTitle1", "OrderDescription1", 19.99, DateTime.Now);
            Order order2 = new Order("OrderTitle2", "OrderDescription2", 29.99, DateTime.Now);
            vendor.Orders.Add(order1);
            vendor.Orders.Add(order2);

            double totalOrdersPrice = vendor.GetTotalOrdersPrice();

            Assert.AreEqual(19.99 + 29.99, totalOrdersPrice, "GetTotalOrdersPrice did not return the correct total price");
        }

        [TestMethod]
        public void Vendor_GetTotalOrdersPrice_EmptyOrdersCollection_ReturnsZero()
        {
            Vendor vendor = new Vendor("VendorName", "VendorDescription");

            double totalOrdersPrice = vendor.GetTotalOrdersPrice();

            Assert.AreEqual(0, totalOrdersPrice, "GetTotalOrdersPrice did not return 0 for an empty Orders collection");
        }
    }
}